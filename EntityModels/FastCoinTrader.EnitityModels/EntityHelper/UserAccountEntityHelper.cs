using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastCoinTrader.EnitityModels.EntityHelper
{
    public class UserAccountEntityHelper
    {
        #region Create User Account
        public static bool CreateUserAccount(string emailAddress,string password, string firstname,string surname, string address1, string address2, string address3,string postalCode,string cellphoneNumber,string userRole)
        {
            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {

                try
                {
                    DateTime dateTimeNow = DateTime.Now;
                    context.tbl_UserAccount.Add(
                        new tbl_UserAccount
                        {
                            pk_tbl_UserAccount = Guid.NewGuid(),
                            tbl_UserAccount_EmailAddress = emailAddress,
                            tbl_UserAccount_Password = password,
                            tbl_UserAccount_Firstname = firstname,
                            tbl_UserAccount_CellphoneNumber = cellphoneNumber,
                            tbl_UserAccount_PhysicalAddressLine1 = address1,
                            tbl_UserAccount_PhysicalAddressLine2 = address2,
                            tbl_UserAccount_PhysicalAddressLine3 = address3,
                            tbl_UserAccount_PostalCode = postalCode,
                            tbl_UserAccount_Surname = surname,
                            tbl_UserAccount_UserRole = userRole
                        }
                     );
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO: add proper error, why registration couldn't complete.
                    return false;
                }
            }
        }
        #endregion

        #region AuthenticateUser
        public static bool AuthenticateUser(string username,string password)
        {

            using (FastCoinTraderContext context = new FastCoinTraderContext())
            {
                System.String HashedPassword = System.BitConverter.ToString(((System.Security.Cryptography.SHA512)new System.Security.Cryptography.SHA512Managed()).ComputeHash(System.Text.Encoding.ASCII.GetBytes(password))).Replace("-", "");
                var validatedUser = (from user in context.tbl_UserAccount
                                     where user.tbl_UserAccount_EmailAddress == username 
                                     && user.tbl_UserAccount_Password == HashedPassword
                                     select user).FirstOrDefault();
                return (validatedUser != null); //if there exists a user with this username and password combo.
            }
        }
        #endregion

    }
}
