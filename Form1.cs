using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections.Specialized;
using System.Diagnostics;

namespace ArmaCore_Client
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();

            // Get the steam path from the registry.
            var steamPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "") as string;

            // We need the path to the steam folder.
            if (String.IsNullOrEmpty(steamPath))
                throw new InvalidOperationException("Unable to locate the steam folder");

            // Set the module directory to steam.
            SetDllDirectory(steamPath);

            // Load the steam client library.
            _handle = LoadLibraryEx(Environment.Is64BitProcess ?
                "steamclient64.dll" : "steamclient.dll", IntPtr.Zero, 8);

            // Restore default path.
            SetDllDirectory(null);

            // We have to be able to load the library.
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Unable to load steamclient.dll");

            // Get the virtual table address of the steam client interface.
            _steamClientVirtualTable = GetSteamClientVirtualTableAddress();

            // Make sure we have the virtual table address.#FF0000
            if (_steamClientVirtualTable == IntPtr.Zero)
                throw new InvalidOperationException("Unable to get the address of ISteamClient012");
        }

        public static class Globals
        {
            public static string steam64ID;
            public static string serverIP;
            public static int whitelisted;
            public static int blacklisted;
            public static int adminlvl;
            public static string a3Path;
            public static List<string> FTPFilesFound = new List<string>();
            public static string[] FilesFoundDelete;
            public static int FTPFiles = 0;
            public static int FTPFilesDownloaded = 0;
            public static bool FileDownload_InProgress = false;
            public static bool CancelDownload = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public class Server_Info
        {
            public string personaname { get; set; }
            public string players { get; set; }
            public string max_players { get; set; }
            public string avatarmedium { get; set; }
            public string Name { get; set; }
        }

        public void pingServer()
        {
            using (Ping p = new Ping())
            {
                while (true)
                {            
                    var ping = p.Send(Globals.serverIP).RoundtripTime.ToString();
                    var pingMS = Int32.Parse(ping);
                    
                    if (pingMS < 55)
                    {
                        labelsrvPing.Invoke((MethodInvoker)(() => {
                            labelsrvPing.Text = ping + "ms";
                            labelsrvPing.ForeColor = Color.DarkGreen;
                        }));
                    } else if (pingMS > 55 && pingMS < 80)
                    {
                        labelsrvPing.Invoke((MethodInvoker)(() => {
                            labelsrvPing.Text = ping + "ms";
                            labelsrvPing.ForeColor = Color.GreenYellow;
                        }));
                    } else if (pingMS > 80)
                    {
                        labelsrvPing.Invoke((MethodInvoker)(() => {
                            labelsrvPing.Text = ping + "ms";
                            labelsrvPing.ForeColor = Color.DarkRed;
                        }));
                    }
                
                    Thread.Sleep(3000);
                }
            }
        }

        public void ServerStatus()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string json_result = client.DownloadString("https://api.steampowered.com/IGameServersService/GetServerList/v1/?filter=\\appid\\107410\\gameaddr\\" + Globals.serverIP + ":2302 &key=8EBF814ECA6B306B6A1AF2FEA5F4B62D");

                    var data = (JObject)JsonConvert.DeserializeObject(json_result);
                    var result = data.SelectToken("response.servers").ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Server_Info[] ServerInfo = js.Deserialize<Server_Info[]>(result);

                    foreach (var i in ServerInfo)
                    {
                        labelsrvName.Invoke((MethodInvoker)(() => labelsrvName.Text = i.Name));
                        labelsrvOnline.Invoke((MethodInvoker)(() => labelsrvOnline.Text = i.players + " / " + i.max_players));
                        labelsrvStatus.Invoke((MethodInvoker)(() => labelsrvStatus.Text = "Online"));
                        labelsrvStatus.Invoke((MethodInvoker)(() => labelsrvStatus.ForeColor = Color.DarkGreen));
                    }
                }
                catch
                {
                    labelsrvName.Invoke((MethodInvoker)(() => labelsrvName.Text = "N/A"));
                    labelsrvOnline.Invoke((MethodInvoker)(() => labelsrvOnline.Text = "N/A"));
                    labelsrvStatus.Invoke((MethodInvoker)(() => labelsrvStatus.Text = "Offline"));
                    labelsrvStatus.Invoke((MethodInvoker)(() => labelsrvStatus.ForeColor = Color.DarkRed));
                }
            }
        }

        public void loadCheckBoxes()
        {
            checkshowScriptErrors.Checked = false;
            checkNoSplash.Checked = false;
            checkNoPause.Checked = false;
            checknologs.Checked = false;
            checkSkipIntro.Checked = false;
            checkWindow.Checked = false;
            check64Bit.Checked = false;

            if (Properties.Settings.Default.showScriptErrors)
            {
                checkshowScriptErrors.Checked = true;
            }
            if (Properties.Settings.Default.NoSplash)
            {
                checkNoSplash.Checked = true;
            }
            if (Properties.Settings.Default.noPause)
            {
                checkNoPause.Checked = true;
            }
            if (Properties.Settings.Default.noLogs)
            {
                checknologs.Checked = true;
            }
            if (Properties.Settings.Default.skipIntro)
            {
                checkSkipIntro.Checked = true;
            }
            if (Properties.Settings.Default.Window)
            {
                checkWindow.Checked = true;
            }
            if (Properties.Settings.Default.A364Bit)
            {
                check64Bit.Checked = true;
            }
        }

        public void loadClientStats()
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection()
                {
                    {"Steam64", Globals.steam64ID}
                };

                string pagesource = Encoding.UTF8.GetString(client.UploadValues("http://" + Globals.serverIP + "/getUserStats.php", postData));
                List<string> jsonlist = JsonConvert.DeserializeObject<List<string>>(pagesource);

                int index = 0;

                foreach (var value in jsonlist)
                {
                    switch(index)
                    {
                        case 0:
                            Globals.whitelisted = Int32.Parse(value);
                            break;
                        case 1:
                            Globals.blacklisted = Int32.Parse(value);
                            break;
                        case 2:
                            Globals.adminlvl = Int32.Parse(value);
                            break;
                        case 3:
                            txtCash.Invoke((MethodInvoker)(() => txtCash.Text = "$" + String.Format("{0:n0}", Int32.Parse(value))));
                            break;
                        case 4:
                            txtBank.Invoke((MethodInvoker)(() => txtBank.Text = "$" + String.Format("{0:n0}", Int32.Parse(value))));
                            break;
                        case 5:
                            TimeSpan time = TimeSpan.FromSeconds(Int32.Parse(value));
                            string str = time.ToString(@"hh\:mm\:ss");
                            txtPlaytime.Invoke((MethodInvoker)(() => txtPlaytime.Text = str));
                            break;
                    }
                    index++;
                }

                if (Globals.whitelisted == 1)
                {
                    labelWhitelisted.Invoke((MethodInvoker)(() => labelWhitelisted.Text = "You are whitelisted for ArmaCore!"));
                    labelWhitelisted.Invoke((MethodInvoker)(() => labelWhitelisted.ForeColor = Color.DarkGreen));
                }
                else
                {
                    labelWhitelisted.Invoke((MethodInvoker)(() => labelWhitelisted.Text = "You are not whitelisted!"));
                    labelWhitelisted.Invoke((MethodInvoker)(() => labelWhitelisted.ForeColor = Color.DarkRed));
                }
            };
        }

        public void checkforClientUpdate()
        {
            string currentVersion = this.ProductVersion.ToString();

            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection()
                {
                    {"Steam64", Globals.steam64ID}
                };

                string version = Encoding.UTF8.GetString(client.UploadValues("http://54.39.130.122/version.php", postData));

                if (currentVersion != version)
                {
                    MessageBox.Show("There is a new client version, update starting now!", "New client version", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string pathtoExeFile = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string pathtoUpdater = Path.GetDirectoryName(pathtoExeFile) + "\\ArmaCoreInstaller.exe";
                    System.Diagnostics.Process.Start(pathtoUpdater);
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            checkforClientUpdate();
            labelVersion.Text = "Client Version: " + this.ProductVersion.ToString();
            Globals.steam64ID = GetSteamId().ToString(CultureInfo.InvariantCulture);

            serverCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            Globals.serverIP = "54.39.130.122";

            Task.Run(() => ServerStatus());
            Task.Run(() => loadClientStats());
            Task.Run(() => pingServer());
            loadCheckBoxes();
            button4.Enabled = false;

            using (WebClient client = new WebClient())
            {
                var json_result = client.DownloadString("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=8EBF814ECA6B306B6A1AF2FEA5F4B62D&format=json&steamids=" + Globals.steam64ID);

                var data = (JObject)JsonConvert.DeserializeObject(json_result);
                var result1 = data.SelectToken("response.players").ToString();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Server_Info[] ServerInfo = js.Deserialize<Server_Info[]>(result1);

                foreach (var i in ServerInfo)
                {

                    labelWelcome.Text = "Welcome " + i.personaname + " to ArmaCore Client";
                }

                if (Globals.steam64ID == "")
                {
                    MessageBox.Show("Please login to your steam account before using our launcher!", "Error with steam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            };
     
            
            if (Properties.Settings.Default.a3path != "")
            {
                txt_a3path.Text = Properties.Settings.Default.a3path;
                Globals.a3Path = Properties.Settings.Default.a3path;
            } else
            {
                var steamPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "") as string;
                string arma3Path = @"" + steamPath + "/steamapps/common/Arma 3";
                Globals.a3Path = arma3Path;
                txt_a3path.Text = arma3Path;
            }         
        }

        /// <summary>
        /// Handle to the steamclient.dll.
        /// </summary>
        private readonly IntPtr _handle;

        /// <summary>
        /// Address to the vtable of the steam client.
        /// </summary>
        private readonly IntPtr _steamClientVirtualTable;

        /// <summary>
        /// Call the CreateInterface method in the Steam Client.
        /// </summary>
        private IntPtr CreateInterface(string version)
        {
            // Get the address of CreateInterface.
            var address = GetProcAddress(_handle, "CreateInterface");

            // We require the address of CreateInterface.
            if (address == IntPtr.Zero)
                throw new InvalidOperationException("CreateInterface not found in steamclient.dll");

            // Marshal the function so we can call it.
            var createInterface = (CreateInterfaceFn)Marshal.GetDelegateForFunctionPointer(
                address, typeof(CreateInterfaceFn));

            // Call the function.
            return createInterface(version, IntPtr.Zero);
        }

        /// <summary>
        /// Get the virtual table address of the ISteamClient012 interface.
        /// </summary>
        private IntPtr GetSteamClientVirtualTableAddress()
        {
            // Use CreateInterface to create the interface and return a pointer.
            var address = CreateInterface("SteamClient012");

            // Read the pointer to the vtable.
            return Marshal.ReadIntPtr(address);
        }

        /// <summary>
        /// Create a steam pipe and return the handle.
        /// </summary>
        private int CreateSteamPipe()
        {
            // The CreateSteamPipe function is index 0 in the vtable.
            var createSteamPipe = (CreateSteamPipeFn)Marshal.GetDelegateForFunctionPointer(
                Marshal.ReadIntPtr(_steamClientVirtualTable, 0 * IntPtr.Size), typeof(CreateSteamPipeFn));

            // Call the method and return the handle.
            return createSteamPipe(_steamClientVirtualTable);
        }

        /// <summary>
        /// Create a steam pipe and return the handle.
        /// </summary>
        private bool ReleaseSteamPipe(int hSteamPipe)
        {
            // The BReleaseSteamPipe function is index 1 in the vtable.
            var releaseSteamPipe = (ReleaseSteamPipeFn)Marshal.GetDelegateForFunctionPointer(
                Marshal.ReadIntPtr(_steamClientVirtualTable, 1 * IntPtr.Size), typeof(ReleaseSteamPipeFn));

            // Call the method and return the status.
            return releaseSteamPipe(_steamClientVirtualTable, hSteamPipe);
        }

        /// <summary>
        /// Get a handle to the global user.
        /// </summary>
        private int ConnectToGlobalUser(int hSteamPipe)
        {
            // The ConnectToGlobalUser function is index 2 in the vtable.
            var connectToGlobalUser = (ConnectToGlobalUserFn)Marshal.GetDelegateForFunctionPointer(
                Marshal.ReadIntPtr(_steamClientVirtualTable, 2 * IntPtr.Size), typeof(ConnectToGlobalUserFn));

            // Call the method and return the handle.
            return connectToGlobalUser(_steamClientVirtualTable, hSteamPipe);
        }

        /// <summary>
        /// Release the handle to the steam user.
        /// </summary>
        private void ReleaseUser(int hSteamPipe, int hSteamUser)
        {
            // The ReleaseUser function is index 4 in the vtable.
            var releaseUser = (ReleaseUserFn)Marshal.GetDelegateForFunctionPointer(
                Marshal.ReadIntPtr(_steamClientVirtualTable, 4 * IntPtr.Size), typeof(ReleaseUserFn));

            // Call the method to release the user handle.
            releaseUser(_steamClientVirtualTable, hSteamPipe, hSteamUser);
        }

        /// <summary>
        /// Get the steam id of the current user.
        /// </summary>
        public UInt64 GetSteamId()
        {
            try
            {
                // Create a steam pipe and connect to the global user.
                var hSteamPipe = CreateSteamPipe();
                var hSteamUser = ConnectToGlobalUser(hSteamPipe);

                // The GetSteamUser function is index 5 in the vtable.
                var getSteamUser = (GetSteamUserFn)Marshal.GetDelegateForFunctionPointer(
                    Marshal.ReadIntPtr(_steamClientVirtualTable, 5 * IntPtr.Size), typeof(GetSteamUserFn));

                // Get the address where we can find the vtable address.
                var steamUserAddress = getSteamUser(_steamClientVirtualTable, hSteamUser, hSteamPipe, "SteamUser012");

                // Get the virtual table of the user.
                var steamUserVirtualTableAddress = Marshal.ReadIntPtr(steamUserAddress);

                // The GetSteamId function is index 2 in the vtable.
                var getSteamId = (GetSteamIdFn)Marshal.GetDelegateForFunctionPointer(
                    Marshal.ReadIntPtr(steamUserVirtualTableAddress, 2 * IntPtr.Size), typeof(GetSteamIdFn));

                // Create a variable to hold the steam id.
                UInt64 id = 0;

                // Call the method to read the steam id into the variable.
                getSteamId(steamUserAddress, ref id);

                // Release the global user and steam pipe.
                ReleaseUser(hSteamPipe, hSteamUser);
                ReleaseSteamPipe(hSteamPipe);

                // Return the steam id.
                return id;
            }
            catch
            {
                return 0;
            }

        }


        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal delegate IntPtr CreateInterfaceFn(string version, IntPtr returnCode);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate int CreateSteamPipeFn(IntPtr thisA);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate bool ReleaseSteamPipeFn(IntPtr thisA, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate int ConnectToGlobalUserFn(IntPtr thisA, int hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate void ReleaseUserFn(IntPtr thisA, int hSteamPipe, int hUser);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate IntPtr GetSteamUserFn(IntPtr thisA, int hUser, int hSteamPipe, string pchVersion);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
        internal delegate void GetSteamIdFn(IntPtr thisA, ref UInt64 steamId);

        #endregion

        #region Native

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, UInt32 dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool SetDllDirectory(string lpPathName);

        #endregion

        private void Button3_Click(object sender, EventArgs e)
        {
            if (serverCombo.Text == "EU Server #1 (DEV)" && Globals.adminlvl <= 0)
            {
                MessageBox.Show("Your not whitelisted to join the development server.", "Not whitelisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Globals.whitelisted == 0)
            {
                MessageBox.Show("Your not whitelisted to play on this server!\nvisit: Armacore.net for support.", "Not whitelisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (Globals.blacklisted == 1)
            {
                MessageBox.Show("You have been blacklisted!\nvisit: Armacore.net for support.", "Blacklisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string arma3Path = txt_a3path.Text;

                if (Directory.Exists(arma3Path) == false)
                {
                    MessageBox.Show("ArmA 3 path not found! " + arma3Path, "ArmA 3 path error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string arma3exeFile = "";
                    if (Properties.Settings.Default.A364Bit)
                    {
                        arma3exeFile = @"" + arma3Path + "/arma3_x64.exe";
                    }
                    else
                    {
                        arma3exeFile = @"" + arma3Path + "/arma3.exe";
                    }

                    if (!(File.Exists(arma3exeFile)))
                    {
                        MessageBox.Show("Error no ArmA 3 execute file was found! " + arma3exeFile, "Arma3exe not found.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string launchOptions = "-connect=" + Globals.serverIP + " -port=2302 -password=armacoreFirst169420 -mod=@ArmaCore";
                        if (Properties.Settings.Default.showScriptErrors)
                        {
                            launchOptions += " -showScriptErrors";
                        }
                        if (Properties.Settings.Default.NoSplash)
                        {
                            launchOptions += " -noSplash";
                        }
                        if (Properties.Settings.Default.noPause)
                        {
                            launchOptions += " -noPause";
                        }
                        if (Properties.Settings.Default.noLogs)
                        {
                            launchOptions += " -noLogs";
                        }
                        if (Properties.Settings.Default.skipIntro)
                        {
                            launchOptions += " -skipIntro";
                        }
                        if (Properties.Settings.Default.Window)
                        {
                            launchOptions += " -Window";
                        }

                        System.Diagnostics.Process.Start(arma3exeFile, launchOptions);
                    }
                }
            }       
        }

        private void CheckshowScriptErrors_CheckedChanged(object sender, EventArgs e)
        {
            if (checkshowScriptErrors.Checked)
            {
                Properties.Settings.Default.showScriptErrors = true;
            } else
            {
                Properties.Settings.Default.showScriptErrors = false;
            }

            Properties.Settings.Default.Save();
        }

        private void Checknologs_CheckedChanged(object sender, EventArgs e)
        {
            if (checknologs.Checked)
            {
                Properties.Settings.Default.noLogs = true;
            }
            else
            {
                Properties.Settings.Default.noLogs = false;
            }

            Properties.Settings.Default.Save();
        }

        private void CheckNoPause_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNoPause.Checked)
            {
                Properties.Settings.Default.noPause = true;
            }
            else
            {
                Properties.Settings.Default.noPause = false;
            }

            Properties.Settings.Default.Save();
        }

        private void CheckSkipIntro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSkipIntro.Checked)
            {
                Properties.Settings.Default.skipIntro = true;
            }
            else
            {
                Properties.Settings.Default.skipIntro = false;
            }

            Properties.Settings.Default.Save();
        }

        private void CheckWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWindow.Checked)
            {
                Properties.Settings.Default.Window = true;
            }
            else
            {
                Properties.Settings.Default.Window = false;
            }

            Properties.Settings.Default.Save();
        }

        private void CheckNoSplash_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNoSplash.Checked)
            {
                Properties.Settings.Default.NoSplash = true;
            }
            else
            {
                Properties.Settings.Default.NoSplash = false;
            }

            Properties.Settings.Default.Save();
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check64Bit.Checked)
            {
                Properties.Settings.Default.A364Bit = true;
            }
            else
            {
                Properties.Settings.Default.A364Bit = false;
            }

            Properties.Settings.Default.Save();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            loadClientStats();
        }

        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        private string[] CurrentFiles;

        private static string GetFileSize(Uri uriPath)
        {
            var webRequest = HttpWebRequest.Create(uriPath);
            webRequest.Method = "HEAD";

            using (var webResponse = webRequest.GetResponse())
            {
                var fileSize = webResponse.Headers.Get("Content-Length");
                return fileSize;
            }
        }

        public void DownloadFile(string urlAddress, string location, string filename, string path)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();


                this.Invoke((MethodInvoker)(() =>
                {
                    text_fileDownloading.Text = "Downloading File: " + filename;
                }));


                var size = GetFileSize(new Uri(urlAddress));

                bool fileUptoDate = false;

                if (File.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\" + filename) || File.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\" + filename))
                {              
                        string fileTypeurl = @"" + urlAddress;
                        string fileType = System.IO.Path.GetExtension(fileTypeurl);
                        long length = 1;

                        if (fileType == ".pbo" || fileType == ".ebo" || fileType == ".bisign")
                        {
                            if (File.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\" + filename))
                            {
                                length = new System.IO.FileInfo(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\" + filename).Length;
                            }

                        }
                        else
                        {
                            if (File.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\" + filename))
                            {
                                length = new System.IO.FileInfo(@"" + Globals.a3Path + "\\@ArmaCore\\" + filename).Length;
                            }
                        }


                        if (Int32.Parse(size) == length)
                        {
                            fileUptoDate = true;
                        }
                }

                if (fileUptoDate == false)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        progressBar2.Minimum = 0;
                        progressBar2.Value = 0;
                        progressBar2.Maximum = 100;
                    }));

                    try
                    {
                        // Start downloading the file
                        webClient.DownloadFileAsync(new Uri(urlAddress), location);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Globals.FTPFilesDownloaded++;
                    Globals.FileDownload_InProgress = false;

                    this.Invoke((MethodInvoker)(() =>
                    {
                        progressBar1.Value = Globals.FTPFilesDownloaded;
                    }));
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                // Calculate download speed and output it to labelSpeed.
                text_speed.Text = string.Format("Download Speed: {0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

                // Update the progressbar percentage only when the value is not the same.
                progressBar2.Value = e.ProgressPercentage;

                // Show the percentage on our label.
                labelPerc.Text = "File Download Percentage: " + e.ProgressPercentage.ToString() + "%";

                // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
                labelDownloaded.Text = string.Format("Downloaded: {0} MB's / {1} MB's",
                    (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                    (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            }));

        }



        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                Globals.CancelDownload = false;
                Globals.FileDownload_InProgress = false;
            }
            else
            {
                //Finished
                Globals.FileDownload_InProgress = false;
                Globals.FTPFilesDownloaded++;

                this.Invoke((MethodInvoker)(() =>
                {
                    progressBar1.Value = Globals.FTPFilesDownloaded;
                }));
            }
        }

        public async void SyncFilesAsync(string FTPHost, string FTPUser, string FTPPW, string DownloadURL)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    text_Sync.Text = "Syncing...";
                }));

                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create("ftp://" + FTPHost);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                NetworkCredential credentials = new NetworkCredential(FTPUser, FTPPW);
                listRequest.Credentials = credentials;

                List<string> lines = new List<string>();

                using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        lines.Add(listReader.ReadLine());
                    }

                    listReader.Close();
                }

                Globals.FTPFilesFound.Clear();
                Globals.FTPFiles = 0;
                Globals.FTPFilesDownloaded = 0;

                foreach (string line in lines)
                {
                    string[] tokens = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];

                    Globals.FTPFilesFound.Add(name);
                    Globals.FTPFiles++;
                }

                this.Invoke((MethodInvoker)(() =>
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = Globals.FTPFiles;
                }));

                if (!(Directory.Exists(Globals.a3Path + "\\@ArmaCore\\addons\\")))
                {
                    Directory.CreateDirectory(Globals.a3Path + "\\@ArmaCore\\addons\\");
                }

                CurrentFiles = Directory.GetFiles(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\", "*");
                string path = Globals.a3Path;

                bool FileFound;

                foreach (string file in CurrentFiles)
                {
                    FileFound = false;

                    string filenew = Path.GetFileName(file);

                    foreach (string filename in Globals.FTPFilesFound)
                    {
                        if (filenew == filename)
                        {
                            FileFound = true;
                        }
                    }

                    if (FileFound == false)
                    {
                        File.Delete(file);
                        Globals.FTPFilesFound.Remove(file);
                        Globals.FTPFiles = Globals.FTPFiles - 1;
                    }
                }

                if (Globals.FTPFiles <= 0)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {

                        progressBar1.Value = 0;
                    }));
                }

                this.Invoke((MethodInvoker)(() =>
                {
                    progressBar1.Maximum = Globals.FTPFiles;
                }));

                bool canceled = false;

                Globals.CancelDownload = false;
                Globals.FileDownload_InProgress = false;

                foreach (string file in Globals.FTPFilesFound)
                {
                    if (Globals.CancelDownload == true)
                    {
                        Globals.CancelDownload = false;
                        canceled = true;
                        break;
                    }

                    Globals.FileDownload_InProgress = true;

                    this.Invoke((MethodInvoker)(() =>
                    {
                        text_Sync.Text = "Syncing file " + file + "...";
                    }));

                    string fileTypeurl = @"" + DownloadURL + file;
                    string fileType = System.IO.Path.GetExtension(fileTypeurl);

                    if (fileType == ".pbo" || fileType == ".ebo" || fileType == ".bisign")
                    {
                        DownloadFile(DownloadURL + file, @"" + path + "\\@ArmaCore\\addons\\" + file, file, path);
                    }
                    else
                    {
                        DownloadFile(DownloadURL + file, @"" + path + "\\@ArmaCore\\" + file, file, path);
                    }


                    await Task.Delay(50);

                    while (Globals.FileDownload_InProgress == true)
                    {
                        await Task.Delay(50);
                        if (Globals.CancelDownload == true)
                        {
                            break;
                        }
                    }
                }


                if (canceled == false)
                {
                    MessageBox.Show("Download finished!", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        text_Sync.Text = "";
                        text_fileDownloading.Text = "Downloading File:";
                        text_speed.Text = "Download Speed:";
                        labelPerc.Text = "File Download Percentage:";
                        labelDownloaded.Text = "Downloaded:";

                        progressBar1.Value = 0;
                        progressBar2.Value = 0;

                        button4.Enabled = false;
                        button5.Enabled = true;
                        button3.Enabled = true;
                    }));
                }
                else
                {
                    MessageBox.Show("Download canceled!", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        text_Sync.Text = "";
                        text_fileDownloading.Text = "Downloading File:";
                        text_speed.Text = "Download Speed:";
                        labelPerc.Text = "File Download Percentage:";
                        labelDownloaded.Text = "Downloaded:";

                        progressBar1.Value = 0;
                        progressBar2.Value = 0;

                        button4.Enabled = false;
                        button5.Enabled = true;
                        button3.Enabled = true;
                    }));
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString(), "Error with syncing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Globals.whitelisted == 0)
            {
                MessageBox.Show("Your not whitelisted for this server!\nvisit: Armacore.net for support.", "Not whitelisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Globals.blacklisted == 1)
            {
                MessageBox.Show("You have been blacklisted!\nvisit: Armacore.net for support.", "Blacklisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button5.Enabled = false;
                button4.Enabled = true;
                button3.Enabled = false;
                Task.Run(() => SyncFilesAsync(Globals.serverIP, "acclient", "sdSa_1!acClientSeCXZ6732", "http://" + Globals.serverIP + "/acclient/"));
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Globals.whitelisted == 0)
            {
                MessageBox.Show("Your not whitelisted for this server!\nvisit: Armacore.net for support.", "Not whitelisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Globals.blacklisted == 1)
            {
                MessageBox.Show("You have been blacklisted!\nvisit: Armacore.net for support.", "Blacklisted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Globals.CancelDownload = true;
                button4.Enabled = false;
                button5.Enabled = true;
                button3.Enabled = true;
            }
        }

        public void removeBiSigns()
        {
            if (!(Directory.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\")))
            {
                MessageBox.Show("@ArmaCore folder was not found in your ArmA 3 directory \nPath: " + Globals.a3Path);
            }
            else
            {
                MessageBox.Show("Removing bisigns, this may take a few seconds!", "Deleting bisigns", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CurrentFiles = Directory.GetFiles(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\", "*.bisign", SearchOption.AllDirectories);
                foreach (string file in CurrentFiles)
                {
                    string filenew = Path.GetFileName(file);
                    if (File.Exists(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\" + filenew))
                    {
                        File.Delete(@"" + Globals.a3Path + "\\@ArmaCore\\addons\\" + filenew);
                    }
                }

                MessageBox.Show("Bisigns removed, please sync your addons again to get the new bisigns!", "Bisigns removed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invoke((MethodInvoker)(() =>
                {
                    linkLabel1.Enabled = true;
                }));
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task.Run(() => removeBiSigns());
            linkLabel1.Enabled = false;
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath.ToString();
            if (path != "")
            {
                txt_a3path.Text = path;
                Globals.a3Path = path;
                Properties.Settings.Default.a3path = path;
            } 
        }

        private void ServerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(serverCombo.Text)
            {
                case "Canada Server #1":
                    Globals.serverIP = "54.39.130.122";
                    break;
                case "EU Server #1 (DEV)":
                    Globals.serverIP = "185.181.8.137";
                    break;
            }

            Task.Run(() => ServerStatus());
            Task.Run(() => loadClientStats());
        }
    }
}
