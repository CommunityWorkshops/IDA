﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA.Models
{
    [Serializable]
    class CurrentFileEditorSettings
    {
        public string FullPathToFile { get; set; } // Fully Qualified path to the file being displayed
        public string filename { get; set; } // For displaying in the tab
        public string fileExtension { get; set; } // So we know what icon to display amongst other things like the Lexer to use
        public string caretLocation { get; set; } // So when the document is re-opened the caret can be placed back where it was        
    }
}
