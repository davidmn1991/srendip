﻿using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace PorpoiseMobileApp.iOS
{
    public class PickingMediaFromGallery
    {
        public PickingMediaFromGallery()
        {
            
        }

        public UIImage image;

        UIViewController view = new UIViewController();


        TaskCompletionSource<Stream> taskCompletionSource;

        UIImagePickerController imagePicker;




        public Task<Stream> GetImageStreamAsync(UIViewController view)
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController()
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;



            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);

            // Return Task object
            taskCompletionSource = new TaskCompletionSource<Stream>();

            this.view = view;

            return taskCompletionSource.Task;

            
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
              image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {

                // Convert UIImage to .NET Stream object
                NSData data = image.AsJPEG(1);
                Stream stream = data.AsStream();

                UnregisterEventHandlers();

                // Set the Stream as the completion of the Task
                taskCompletionSource.SetResult(stream);

            }
            else
            {
                UnregisterEventHandlers();
                taskCompletionSource.SetResult(null);
            }
            
            imagePicker.DismissModalViewController(true);

            this.view.ViewWillAppear(false);

            
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }

        void UnregisterEventHandlers()
        {
            imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled -= OnImagePickerCancelled;
        }


    }
}
