using System;
using SQLite;
using System.IO;
using UIKit;

namespace phoneBook
{
    public partial class ViewController : UIViewController
    {
        public static string DbName = "PhoneBookv2.db3";
        public static string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DbName);

        partial void BtnCreate_TouchUpInside(UIButton sender)
        {
            try{

                var db = new SQLiteConnection(DbPath);
                db.CreateTable<Contact>();


                string name = TFName.Text;
                string phoneNumber = TFNumber.Text;

                var contact = new Contact
                {
                    name = name,
                    number = phoneNumber,

                };

                db.Insert(contact);



                ContactsTableViewController controller = this.Storyboard.InstantiateViewController("ListContacts") as ContactsTableViewController;

                this.NavigationController.PushViewController(controller, true);




            }
            catch(Exception ex){


            }
           
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
