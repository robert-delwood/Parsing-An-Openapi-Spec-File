using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenAPI_Parser_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadYAMLFile();
        }

        private void ReadYAMLFile()
        {
            var json = File.ReadAllText(@"E:\Development\OpenAPI_Parser_Sample\openapi_openweathermap.yaml");
            OpenApiDocument parsedDocument = new OpenApiStringReader().Read(json, out var diagnostic);
            if (diagnostic.Errors.Count != 0)
            {
                MessageBox.Show("An error was detected.", "Error in OpenAPI Format", MessageBoxButtons.OK);
                return;
            }

            var keyList = parsedDocument.Paths.ToList();

            listBox1.DisplayMember = "Key";
            listBox1.DataSource = keyList;
            label1.Text = string.Format("Items found: {0}", keyList.Count.ToString());
        }
    }
}
