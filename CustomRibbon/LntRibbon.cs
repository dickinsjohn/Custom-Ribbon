using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace CustomRibbon
{   
    //Creating new Class as external application to create a new ribbon
    public class LntRibbon : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            //Return Suceed
            return Result.Succeeded;

            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                //Create a new Ribbon Tab
                string tabName = "L&T Add-ins";
                application.CreateRibbonTab(tabName);

                if (File.Exists(@"C:\Completed DLL\Numbering\Numbering.dll") && 
                    File.Exists(@"C:\Completed DLL\AddTYP\Add(TYP).dll")&&
                    File.Exists(@"C:\Completed DLL\RotateComponent\RotateComponent.dll"))
                {
                    //**************
                    // Create a new Ribbon Panel
                    RibbonPanel annotationPanel = application.CreateRibbonPanel(tabName, "Annotation Tools");

                    //populating annotation panel with the numbering tool command button
                    NumberingTools(annotationPanel);

                    //add separator in the document management panel
                    annotationPanel.AddSeparator();

                    //populating annotation panel with the numbering tool command button
                    AddTYP(annotationPanel);

                    //add separator in the document management panel
                    annotationPanel.AddSeparator();

                    //populating annotation panel with the numbering tool command button
                    RotateComponent(annotationPanel);
                    //**************

                }

                if (File.Exists(@"C:\Completed DLL\Numbering\Numbering.dll"))
                {
                    //**************
                    // Create a new Ribbon Panel
                    RibbonPanel conversionPanel = application.CreateRibbonPanel(tabName, "Revit to Navis");

                    //populating revit to navis panel with link document command button
                    RevittoNavis(conversionPanel);
                    //**************
                }


                if (File.Exists(@"C:\Completed DLL\Link File\Link File.dll") 
                    && File.Exists(@"C:\Completed DLL\Open File\OpenFile.dll"))
                {
                    //**************
                    // Create a new Ribbon Panel
                    RibbonPanel documentManagementPanel = application.CreateRibbonPanel(tabName, "Document Management");

                    //populating document management panel with link document command button
                    LinkDocument(documentManagementPanel);

                    //add separator in the document management panel
                    documentManagementPanel.AddSeparator();

                    //populating document management panel with show document command button
                    ShowDocument(documentManagementPanel);
                    //**************
                }


                if (File.Exists(@"C:\Completed DLL\FEMS Supports\FEMS Supports.dll")
                    && File.Exists(@"C:\Completed DLL\Spacing Configuration\SpacingConfiguration.dll"))
                {
                    //**************
                    // Create a new Ribbon Panel
                    RibbonPanel supportProvision = application.CreateRibbonPanel(tabName, "Auto Support Generation");

                    //populating Provide Support panel with FEMS Pipe Support command button
                    FEMSSupport(supportProvision);

                    //add separator in the Auto support generation panel
                    supportProvision.AddSeparator();

                    //populating Provide Support panel with Spacing Configuration command button
                    SpacingConfiguration(supportProvision);
                    //**************
                }

                //MORE PANELS AND TOOLS CAN BE ADDED HERE

                //Return Succeed
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                return Autodesk.Revit.UI.Result.Failed;
            }
            throw new NotImplementedException();
        }


        //method to add a new command button to the annotation tools panel
        private void NumberingTools (RibbonPanel panel)
        {            
            PushButton pushButton = panel.AddItem(new PushButtonData("Tool for numbering the selected elements automatically.",
                "Auto\nNumbering", @"C:\Completed DLL\Numbering\Numbering.dll", "Numbering.Numbering")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\Numbering.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button to the document management panel
        private void LinkDocument(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Tool to link the family or element with a document.",
                "Link\nDocument", @"C:\Completed DLL\Link File\Link File.dll", "Link_File.LinkFile")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\LinkFile.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;            
        }


        //method to add a new command button to the document management panel
        private void ShowDocument(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Tool to display the document linked with family or element.",
                "Show\nDocument", @"C:\Completed DLL\Open File\OpenFile.dll", "OpenFile.OpenFile")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\OpenFile.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button to the document management panel
        private void RevittoNavis(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Click to Convert the Revit files to Navisworks files.",
                "Revit to\nNaviworks", @"C:\Completed DLL\Numbering\Numbering.dll", "Numbering.Numbering")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\Conversion.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button to the Annotation Tools
        private void AddTYP(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Click to Add (TYP) to the Dimensions.",
                "Add (TYP)", @"C:\Completed DLL\AddTYP\Add(TYP).dll", "Add_TYP_.AddTYP")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\TYP.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button to the Annotation Tools
        private void RotateComponent(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Click to Rotate tags.",
                "Rotate\nComponents", @"C:\Completed DLL\RotateComponent\RotateComponent.dll", "RotateComponent.Rotation")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\Rotate.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button to the provide support
        private void FEMSSupport(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Tool to provide supports in the FEMS piping system.",
                "FEMS Pipe\nSupports", @"C:\Completed DLL\FEMS Supports\FEMS Supports.dll", "FEMS_Supports.FEMSSupports")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\FEMS_Supports.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }


        //method to add a new command button for support spacing configuration
        private void SpacingConfiguration(RibbonPanel panel)
        {
            PushButton pushButton = panel.AddItem(new PushButtonData("Tool to change the support spacing configuration.",
                "Spacing\nConfiguration", @"C:\Completed DLL\Spacing Configuration\SpacingConfiguration.dll", "SpacingConfiguration.SpacingConfiguration")) as PushButton;
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Completed DLL\Icons\SpacingConfiguration.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
        }
    }
}