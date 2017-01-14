using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationReservations.Common;

namespace VacationReservations
{
    public partial class StringEncryptorTester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void processButton_Click(object sender, EventArgs e)
        {
            string stringToEncrypt = encryptBox.Text;
            string stringToDecrypt = decryptBox.Text;
            string encryptedString =
            StringEncryptor.Encrypt(stringToEncrypt);
            if (stringToDecrypt == "")
            {
                stringToDecrypt = encryptedString;
            }
            string decryptedString =
            StringEncryptor.Decrypt(stringToDecrypt);
            StringBuilder sb = new StringBuilder();
            sb.Append("Encrypted data: ");
            sb.Append(encryptedString);
            sb.Append("<br />Decrypted data: ");
            sb.Append(decryptedString);
            result.Text = sb.ToString();
        }
    }
}