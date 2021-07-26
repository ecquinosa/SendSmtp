using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SendSmtp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(credFile))
            {
                var decryptedString = AesOperation.DecryptString(key, File.ReadAllText(credFile));
                txtHost.Text = decryptedString.Split('|')[0];
                txtPort.Text = decryptedString.Split('|')[1];
                txtUser.Text = decryptedString.Split('|')[2];
                txtPassword.Text = decryptedString.Split('|')[3];
            }
        }

        private string key = "e171a9998a4e413311112ea2315a1412";
        private string credFile = Application.StartupPath + "\\cred";

        public bool SendNotification()
        {
            SmtpClient client = new SmtpClient();

            try
            {
                string emailCred = string.Format("{0}|{1}|{2}|{3}", txtHost.Text, txtPort.Text, txtUser.Text, txtPassword.Text);
                var encryptedString = AesOperation.EncryptString(key, emailCred);
                File.WriteAllText(credFile, encryptedString);

                client.Port = Convert.ToInt32(txtPort.Text); //587;
                client.Host = txtHost.Text; //"smtp.allcard.com.ph";
                                                                     //client.EnableSsl = true;
                client.Timeout = 10000; //10000;
                //client.EnableSsl = true;
                //client.DeliveryMethod = SmtpDeliveryMethod
                //client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.SMTP_USER.Split('@')[0], Properties.Settings.Default.SMTP_PASS);//("ecquinosa", "earl1106_1c");
                client.Credentials = new System.Net.NetworkCredential(txtUser.Text, txtPassword.Text);//("ecquinosa", "earl1106_1c");


                MailMessage mm = new MailMessage(txtUser.Text, txtRecipient.Text, "SMTP TEST - " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), "TEST MESSAGE"); //("ecquinosa@allcardtech.com.ph", "ecquinosa@allcardtech.com.ph,vsdelafuente@allcardtech.com.ph,agprotacio@allcardtech.com.ph", "test", "test");
                //mm.Bcc.Add("ecquinosa@allcardtech.com.ph");
                mm.BodyEncoding = System.Text.UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                //Attachment attachment = new Attachment(fileAttachment, System.Net.Mime.MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                //ContentDisposition disposition = data.ContentDisposition;
                //disposition.CreationDate = System.IO.File.GetCreationTime(file);
                //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                // Add the file attachment to this email message.
                //mm.Attachments.Add(attachment);

                client.Send(mm);

                //System.Windows.Forms.MessageBox.Show("Test message sent. Check your inbox");
                return true;
            }
            catch (Exception ex)
            {
                txtLog.Text = DateTime.Now.ToString("hh:mm:ss tt ") + "Failed. " + ex.Message;
                //errMsg = ex.Message;
                //Utilities.WriteToRTB(string.Format("SendNotification(): Runtime error {0}", errMsg), ref rtb, ref tssl);
                return false;
            }
            finally
            {
                client = null;
                MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor = Cursors.WaitCursor;

            txtLog.Clear();
            //System.Threading.Thread.Sleep(2000);
            Application.DoEvents();            

            if (txtHost.Text == "")
            {
                MessageBox.Show("Please complete required fields.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPort.Text == "")
            {
                MessageBox.Show("Please complete required fields.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtUser.Text == "")
            {
                MessageBox.Show("Please complete required fields.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please complete required fields.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtRecipient.Text == "")
            {
                MessageBox.Show("Please complete required fields.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtUser.Text.Contains("@"))
            {
                MessageBox.Show("Please Email/ UserId if valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtRecipient.Text.Contains("@"))
            {
                MessageBox.Show("Please Email/ UserId if valid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SendNotification()) txtLog.Text = DateTime.Now.ToString("hh:mm:ss tt ") + "Success. Check sent email.";
            
            this.Enabled = true;
            Cursor = Cursors.Default;
        }

        public class AesOperation
        {
            public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }

            public static string DecryptString(string key, string cipherText)
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
