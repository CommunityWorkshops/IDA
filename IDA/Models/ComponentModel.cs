﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Models
{
    [Serializable]
   public class ComponentModel
    {
        public enum Options
        {
            Analog,
            Digital
        };

        public string ComponentName { get; set; }
        public string ComponentDescription { get; set; }
        public List<Options> ComponentOptions = new List<Options>(); 
        public Image ComponentSchematic { get; set; }
        public Image ComponentLayout { get; set; }
        public List<string> ComponentGlobal = new List<string>();
        public List<string> ComponentAnalogGlobal = new List<string>();
        public List<string> ComponentDigitalGlobal = new List<string>();
        public List<string> ComponentSetup = new List<string>();
        public List<string> ComponentAnalogSetup = new List<string>();
        public List<string> ComponentDigitalSetup = new List<string>();
        public List<string> ComponentLoop = new List<string>();
        public List<string> ComponentAnalogLoop = new List<string>();
        public List<string> ComponentDigitalLoop = new List<string>();

        //version 1.03
        public Image ComponentIcon { get; set; }


    }
}

// Version History
// Template Format 1.03
// Added Icon
// Icon = The path to the image which is displayed in the toolbox for this component


// Template format 1.02
// Version = comma list of platform versions that this template belongs to.
// Name = Displayed in the Toolbox
// Description = Displayed at the bottom of the toolbox
// Options = Comma list of which type of IO is available currently only Analog and Digital
// Images = the Root folder to Schematic and Layout images in subfolder of Analog or Digital
// Global = Global settings used in all examples
// Analog Global = Global settings used in Analog Only Examples
// Digital Global = Global settings used in Digital only examples
// Setup = Code used in the Setup function required by all examples
// Analog Setup = Code used in the Setup function required by analog examples
// Digital Setup = Code used in the Setup function required by digital examples
// Loop = Code used in the Loop function required by all examples
// Analog Loop = Code used in the Loop function required by analog examples
// Digital Loop = Code used in the Loop function required by digital examples
//
// Notes: 
// The template parser: 
//    ignores all lines starting with //
//    splits parsed lines on the = sign
//    Blank lines have no content after the = sign                    
//    Ignores case in the tag prior to the = sign
//    the content after the = sign is case sensitive
//    Parser stops reading the document when it finds a line starting with END in capitals
//    Parser starts reading the document when it finds a line starting with START in capitals