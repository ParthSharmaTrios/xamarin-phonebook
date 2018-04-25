using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.IO;
            
            


namespace phoneBook
{
    public partial class ContactsTableViewController : UITableViewController
    {
        List<Contact> contacts;

        public ContactsTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            contacts = new List<Contact>();

		}




        public List<Contact> Read(string db_path ){

            List<Contact> contacts = new List<Contact>();

            using (var con = new SQLiteConnection(db_path)){

                contacts = con.Table<Contact>().ToList();
            }

            return contacts;


        }




		public override void ViewDidAppear(bool animated)
		{
            base.ViewDidAppear(animated);

            contacts = Read(ViewController.DbPath);

            TableView.ReloadData();

		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var cell = tableView.DequeueReusableCell("contactCell", indexPath);
            var data = contacts[indexPath.Row];

            cell.TextLabel.Text = data.name;
            cell.DetailTextLabel.Text = data.number;

            return cell;




		}


		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return contacts.Count;
		}

       
	}
}