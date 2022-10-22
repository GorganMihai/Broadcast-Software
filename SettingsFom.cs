using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Broadcast_Software
{
    public partial class SettingsFom : Form
    {
        DeviceHandler deviceHandler;
        Settings settings;
        private string URL;
        private string Key;
        private int SelectedItem = -1;
        private int VideoIndex = 0;
        private int VideoModIndex = 0;
        private int AudioIndex = 0;
        private List<Settings> settingsList;
        private const string connectionString = "DataSource = Database.db";
        private enum DeleteMod {WithMessage, WithoutMessage }
        private enum AddMode {AddMode, ModifyMod }

        public SettingsFom(DeviceHandler deviceHandler, Settings settings)
        {
            InitializeComponent();
            this.deviceHandler = deviceHandler;
            this.settings = settings;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void SettingsFom_Load(object sender, EventArgs e)
        {            
            foreach (var s in deviceHandler.videoDeviceList)
            {
                VideoSourceBox.Items.Add(s.Name.ToString());
            }

            foreach (var s in deviceHandler.audioDeviceList)
            {
                AudioSourceBox.Items.Add(s.Name.ToString());
            }

            VideoSourceBox.SelectedIndex = settings.GetVideoIndex();
            AudioSourceBox.SelectedIndex = settings.GetAudioIndex();

            tbx_URL.Text = settings.GetURL();
            tbx_Key.Text = settings.GetKey();

            load_Settings();
        }

        private void load_Settings()
        {
            settingsList = new List<Settings>();
            cbx_Favorites.Items.Clear();            

            var query = "SELECT * FROM Settings ";
            using (var Connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(query, Connection);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["ID"];
                        string name = (string)reader["Name"];
                        string url = (string)reader["URL"];
                        string key = (string)reader["Key"];
                        long videoIndex = (long)reader["VideoIndex"];
                        long videoModIndex = (long)reader["VideoModIndex"];
                        long audioIndex = (long)reader["AudioIndex"];

                        settingsList.Add(new Settings((int)id, name, url, key, (int)videoIndex, (int)videoModIndex, (int)audioIndex));
                    }
                }
            }

            foreach (var f in settingsList)
            {
                cbx_Favorites.Items.Add(f.ToString());
            }
        }

        public void addSettings(Settings settings)
        {
            settings.SetVideoIndex(this.VideoIndex);
            settings.SetVideoModIndex(this.VideoModIndex);
            settings.SetAudioIndex(this.AudioIndex);
            settings.SetKey(this.Key);
            settings.SetURL(this.URL);
        }

        private void btn_PasteKey_Click(object sender, EventArgs e)
        {
            tbx_Key.Clear();
            tbx_Key.Text = Clipboard.GetText();
        }

        private void btn_PasteURL_Click(object sender, EventArgs e)
        {
            tbx_URL.Clear();
            tbx_URL.Text = Clipboard.GetText();
        }

        private void VideoSourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoModBox.Items.Clear();
            VideoModBox.Text = null;
            VideoModBox.ForeColor = Color.Gainsboro;

            deviceHandler.CreateDeviceForSettings(VideoSourceBox.SelectedIndex);

            try
            {
                foreach (var mod in deviceHandler.GetVideoCapabilities())
                {
                    VideoModBox.Items.Add(mod.ToString());
                }

                if (deviceHandler.GetVideoCapabilities().Length <= 0)
                {
                    VideoModBox.ForeColor = Color.Red;
                    VideoModBox.Text = "This device has no video mode";
                }
                else
                {
                    VideoModBox.SelectedIndex = settings.GetVideoModIndex();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                this.VideoIndex = VideoSourceBox.SelectedIndex;
            }
        }

        private void VideoModBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.VideoModIndex = VideoModBox.SelectedIndex;
        }

        private void AudioSourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AudioIndex = AudioSourceBox.SelectedIndex;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            this.Key = tbx_Key.Text.Trim();
            this.URL = tbx_URL.Text.Trim();
        }

        public string GetURL()
        {
            return URL + "/" + Key;
        }

        private void Btn_AddToFavorites_Click(object sender, EventArgs e)
        {
            AddToFavorites(AddMode.AddMode);
            int aux = GetIndexFav();
            if (aux != -1) 
            {
                cbx_Favorites.SelectedIndex = aux;
            }

        }

        private int GetIndexFav() 
        {
            int index = 0;
            foreach (var item in cbx_Favorites.Items)
            {
                if (string.Compare(tbx_FavName.Text.Trim(), item.ToString()) == 0)
                {
                    return index;
                }
                index++;
            }
            if (index == cbx_Favorites.Items.Count)
            {
                return -1;
            }
            else 
            {
                return index;
            }
            
        }

        private void cbx_Favorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = cbx_Favorites.SelectedIndex;
            foreach (var item in settingsList)
            {
                if (string.Compare(item.GetName(), cbx_Favorites.SelectedItem.ToString()) == 0)
                {
                    Settings aux = item;
                    tbx_FavName.Text = aux.GetName();
                    try 
                    {
                        VideoSourceBox.SelectedIndex = aux.GetVideoIndex();
                        VideoModBox.SelectedIndex = aux.GetVideoModIndex();
                        AudioSourceBox.SelectedIndex = aux.GetAudioIndex();
                    } 
                    catch (Exception exep) 
                    {                        
                        MessageBox.Show("Please choose a valid Video Device\n\n" + exep.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                    tbx_Key.Text = aux.GetKey();
                    tbx_URL.Text = aux.GetURL();
                    break;
                    }
            }
            if (cbx_Favorites.Text.Length >= 3)
            {
                btn_Modify.Enabled = true;
                btn_Delete.Enabled = true;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (SelectedItem > -1) 
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this item", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteItem(DeleteMod.WithMessage);
                    cbx_Favorites.ResetText();
                    tbx_FavName.Clear();
                    SelectedItem = -1;
                    btn_Modify.Enabled = false;
                    btn_AddToFavorites.Enabled = false;
                    btn_Delete.Enabled = false;
                    ResetAllValues();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }           
        }

        private void tbx_FavName_TextChanged(object sender, EventArgs e)
        {
            if (tbx_FavName.Text.Length >= 3)
            {
                btn_AddToFavorites.Enabled = true;
            }
        }

        private void tbx_FavName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (tbx_FavName.Text.Length >= 3)
                {
                    btn_AddToFavorites.Enabled = true;
                }
                else
                {
                    btn_AddToFavorites.Enabled = false;
                }
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            DeleteItem(DeleteMod.WithoutMessage);
            AddToFavorites(AddMode.ModifyMod);

        }

        private void DeleteItem(DeleteMod deleteMod)
        {
            int id = -1;
            if (SelectedItem != -1)
            {
                foreach (var itm in settingsList)
                {
                    if (string.Compare(itm.GetName(), cbx_Favorites.Items[SelectedItem].ToString()) == 0)
                    {
                        id = itm.GetID();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select one Item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (id == -1)
            {
                MessageBox.Show("Item not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = " DELETE FROM Settings WHERE ID = @ID; ";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    int RowsMod = command.ExecuteNonQuery();
                    if (deleteMod == DeleteMod.WithMessage)
                    {
                        MessageBox.Show("The selected item has been deleted.","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                    load_Settings();                                        
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString(), "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToFavorites(AddMode addMode) 
        {
            if (tbx_FavName.Text.Trim().Length >= 3)
            {
                var query = "INSERT INTO Settings(Name, URL, Key, VideoIndex, VideoModIndex, AudioIndex) " +
                            " VALUES (@Name, @URL, @Key, @VideoIndex, @VideoModIndex, @AudioIndex); ";

                using (var connection = new SQLiteConnection(connectionString))
                {
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", tbx_FavName.Text.Trim());
                    command.Parameters.AddWithValue("@URL", tbx_URL.Text.Trim());
                    command.Parameters.AddWithValue("@Key", tbx_Key.Text.Trim());
                    command.Parameters.AddWithValue("@VideoIndex", (long)VideoSourceBox.SelectedIndex);
                    command.Parameters.AddWithValue("@VideoModIndex", (long)VideoModBox.SelectedIndex);
                    command.Parameters.AddWithValue("@AudioIndex", (long)AudioSourceBox.SelectedIndex);
                    connection.Open();
                    try
                    {
                        int Rows = command.ExecuteNonQuery();

                        if (addMode == AddMode.AddMode)
                        {
                            MessageBox.Show("The item has been added.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                            MessageBox.Show("The selected item has been changed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show("Please insert a new name", "Add item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    load_Settings();                    
                }
            }
            else
            {
                MessageBox.Show("Too short name (the name must have more than 2 letters)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ResetAllValues() 
        {
            VideoSourceBox.SelectedIndex = 0;
            AudioSourceBox.SelectedIndex = 0;
            tbx_Key.Clear();
            tbx_URL.Clear();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }


}
