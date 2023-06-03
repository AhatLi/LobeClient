using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebPWrapper;

namespace LobeClient
{
    public partial class MainForm : Form
    {
        List<string> afterList = new List<string>();
        List<string> beforerList = new List<string>();
        List<TextBox> beforerBoxList = new List<TextBox>();
        int level = 0;
        private static readonly HttpClient client = new HttpClient();
        private object lockObject = new object();

        public MainForm()
        {
            InitializeComponent();
            pathBox.Text = System.Environment.CurrentDirectory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultPannel.Controls.Clear();
            afterList.Clear();
            beforerList.Clear();

            int y = 50;
            if (System.IO.Directory.Exists(pathBox.Text))
            {
                DirectoryInfo info = new DirectoryInfo(pathBox.Text);
                foreach (var item in info.GetFiles())
                {
                    if (!item.Name.ToLower().Contains(".jpg") && !item.Name.ToLower().Contains(".png") &&
                        !item.Name.ToLower().Contains(".jpeg") && !item.Name.ToLower().Contains(".gif") && !item.Name.ToLower().Contains(".webp"))
                        continue;

                    TextBox at = new TextBox();
                    at.SetBounds(20, y, 400, 50);
                    at.Visible = true;
                    at.BringToFront();
                    at.Text = item.Name;
                    afterList.Add(item.Name);

                    resultPannel.Controls.Add(at);

                    beforerList.Add("");

                    y += 50;
                }

                level = 1;
            }
        }

        async void imageProcess(Image image, int i)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);

                var values = new Dictionary<string, string>
                            {
                                { "image", base64String }
                            };

                var stringPayload = JsonConvert.SerializeObject(values);
                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlBox.Text, content);
                var responseString = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(responseString);
                var jToken = jObject.SelectToken("predictions");

                foreach (var token in jToken)
                {
                    beforerList[i] = token.SelectToken("label").ToString();

                    break;
                }
            }
        }

        async void imageProcess2(byte[] imageBytes, int i)
        {
            string base64String = Convert.ToBase64String(imageBytes);

            var values = new Dictionary<string, string>
                        {
                            { "image", base64String }
                        };

            var stringPayload = JsonConvert.SerializeObject(values);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(urlBox.Text, content);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jObject = JObject.Parse(responseString);
            var jToken = jObject.SelectToken("predictions");

            foreach (var token in jToken)
            {
                beforerList[i] = token.SelectToken("label").ToString();

                break;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (level == 2)
                return;

            for (int i = 0; i < afterList.Count; i++)
            {
                var item = afterList[i];
                try
                {
                    if(item.Contains(".webp"))
                    {
                        byte[] rawWebP = File.ReadAllBytes(pathBox.Text + "\\" + item);
                        imageProcess2(rawWebP, i);
                        /*
                        using (WebP webp = new WebP())
                        {
                            var image = webp.Decode(rawWebP);
                            imageProcess((Image)image, i);
                        }
                        */
                    }
                    else
                    {

                        using (Image image = Image.FromFile(pathBox.Text + "\\" + item))
                        {
                            imageProcess(image, i);
                            /*
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();

                                // Convert byte[] to Base64 String
                                string base64String = Convert.ToBase64String(imageBytes);

                                var values = new Dictionary<string, string>
                                {
                                    { "image", base64String }
                                };

                                var stringPayload = JsonConvert.SerializeObject(values);
                                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                                var response = await client.PostAsync(urlBox.Text, content);
                                var responseString = await response.Content.ReadAsStringAsync();

                                JObject jObject = JObject.Parse(responseString);
                                var jToken = jObject.SelectToken("predictions");

                                foreach (var token in jToken)
                                {
                                    beforerList[i] = token.SelectToken("label").ToString();

                                    break;
                                }
                            }
                            */
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            level = 2;


            MessageBox.Show("complete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < afterList.Count; i++)
            {
                try
                {
                    if (!System.IO.File.Exists(pathBox.Text + "\\" + beforerList[i]))
                    {
                        Directory.CreateDirectory(pathBox.Text + "\\" + beforerList[i]);
                    }

                    var after = pathBox.Text + "\\" + afterList[i];
                    var before = pathBox.Text + "\\" + beforerList[i] + "\\" + afterList[i];

                    System.IO.File.Move(after, before);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            MessageBox.Show("complete");
        }
    }
}
