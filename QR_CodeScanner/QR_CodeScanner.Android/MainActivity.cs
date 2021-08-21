using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android;
using Android.Content;
using Android.Provider;
using System.Collections.Generic;
using Android.Util;
using Google.Android.Material.Snackbar;

using QR_CodeScanner.Views;
using Android.Support.V4.App;
using Android.Widget;

using Java.Interop;
using QR_CodeScanner.Droid.Models;
using System.IO;

namespace QR_CodeScanner.Droid
{
   

    [Activity(Label = "QR_CodeScanner", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public string TAG
        {
            get
            {
                return "MainActivity";
            }
        }
        static readonly int REQUEST_CONTACTS = 1;

        static string[] PERMISSIONS_CONTACT = {
            Manifest.Permission.ReadContacts,
            Manifest.Permission.WriteContacts
        };

        Android.Widget.Button button;

        Android.Views.View layout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            layout = FindViewById(Resource.Id.root_layout);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //für BarCode Scanner
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
           


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            //für BarCode Scanner
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_CONTACTS)
            {
                Log.Info(TAG, "Received response for contact permissions request.");

                // We have requested multiple permissions for contacts, so all of them need to be
                // checked.
                if (PermissionUtil.VerifyPermissions(grantResults))
                {
                    // All required permissions have been granted, display contacts fragment.
                    Snackbar.Make(layout, Resource.String.permission_available_contacts, Snackbar.LengthShort).Show();

                    // save contact
                    saveContact();
                }
                else
                {
                    Log.Info(TAG, "Contacts permissions were NOT granted.");
                    Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
                }

            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        





    }

        void RequestContactsPermissions()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReadContacts)
                || ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteContacts))
            {

                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example, if the request has been denied previously.
                Log.Info(TAG, "Displaying contacts permission rationale to provide additional context.");

                // Display a SnackBar with an explanation and a button to trigger the request.
                Snackbar.Make(layout, Resource.String.permission_contacts_rationale,
                    Snackbar.LengthIndefinite).SetAction(Resource.String.ok, new Action<Android.Views.View>(delegate (Android.Views.View obj) {
                        ActivityCompat.RequestPermissions(this, PERMISSIONS_CONTACT, REQUEST_CONTACTS);
                    })).Show();

            }
            else
            {
                // Contact permissions have not been granted yet. Request them directly.
                ActivityCompat.RequestPermissions(this, PERMISSIONS_CONTACT, REQUEST_CONTACTS);
            }
        }

        public void saveContact()
        {
            List<ContentProviderOperation> ops = new List<ContentProviderOperation>();
            NewContact(ref ops, "test", "1234", "2234", "3234", "4234");

            //Add the new contact
            ContentProviderResult[] res;
            try
            {
                res = ContentResolver.ApplyBatch(ContactsContract.Authority, ops);
                ops.Clear();//Add this line   
                Toast.MakeText(this, "contact saved !", ToastLength.Short).Show();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("**************-----------> : " + e.Message);
                Toast.MakeText(this, "contact not saved_message !", ToastLength.Long).Show();
            }
        }
    

    public void NewContact(ref List<ContentProviderOperation> ops, string displayName, string Number1, string Number2, string Number3, string Number4)
        {
            ContentProviderOperation.Builder builder =
                ContentProviderOperation.NewInsert(ContactsContract.RawContacts.ContentUri);
            builder.WithValue(ContactsContract.RawContacts.InterfaceConsts.AccountType, null);
            builder.WithValue(ContactsContract.RawContacts.InterfaceConsts.AccountName, null);
            ops.Add(builder.Build());

            //Name  
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, 0);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                              ContactsContract.CommonDataKinds.StructuredName.ContentItemType);
            builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.DisplayName, displayName);
            //builder.WithValue(ContactsContract.CommonDataKinds.StructuredName.GivenName, firstName);  
            ops.Add(builder.Build());

            //Number1  
            builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
            builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, 0);
            builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                              ContactsContract.CommonDataKinds.Phone.ContentItemType);
            builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, Number1);
            builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type,
                              ContactsContract.CommonDataKinds.Phone.InterfaceConsts.TypeCustom);
            builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data2, (int)PhoneDataKind.Mobile);

            ops.Add(builder.Build());
            //Number2  
            if (!string.IsNullOrEmpty(Number2))
            {
                builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
                builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, 0);
                builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                                  ContactsContract.CommonDataKinds.Phone.ContentItemType);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, Number2);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type,
                                  ContactsContract.CommonDataKinds.Phone.InterfaceConsts.TypeCustom);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data2, (int)PhoneDataKind.Mobile);
                ops.Add(builder.Build());
            }

            if (!string.IsNullOrEmpty(Number3))
            {
                builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
                builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, 0);
                builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                                  ContactsContract.CommonDataKinds.Phone.ContentItemType);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, Number3);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type,
                                  ContactsContract.CommonDataKinds.Phone.InterfaceConsts.TypeCustom);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data2, (int)PhoneDataKind.Mobile);
                ops.Add(builder.Build());
            }

            if (!string.IsNullOrEmpty(Number4))
            {
                builder = ContentProviderOperation.NewInsert(ContactsContract.Data.ContentUri);
                builder.WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, 0);
                builder.WithValue(ContactsContract.Data.InterfaceConsts.Mimetype,
                                  ContactsContract.CommonDataKinds.Phone.ContentItemType);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.Number, Number4);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type,
                                  ContactsContract.CommonDataKinds.Phone.InterfaceConsts.TypeCustom);
                builder.WithValue(ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data2, (int)PhoneDataKind.Mobile);
                ops.Add(builder.Build());
            }

        }

        [Export]
        public void SaveContacts(Android.Views.View v)
        {
            Log.Info(TAG, "Show contacts button pressed. Checking permissions.");

            // Verify that all required contact permissions have been granted.
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts) != (int)Permission.Granted
                || ActivityCompat.CheckSelfPermission(this, Manifest.Permission.WriteContacts) != (int)Permission.Granted)
            {
                // Contacts permissions have not been granted.
                Log.Info(TAG, "Contact permissions has NOT been granted. Requesting permissions.");
                RequestContactsPermissions();
            }
            else
            {
                // Contact permissions have been granted. Show the contacts fragment.
                Log.Info(TAG, "Contact permissions have already been granted. Displaying contact details.");

                //Add the new contact

                saveContact();
            }
        }





    }
}