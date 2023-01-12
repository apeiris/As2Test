//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.1.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace MyNamespace
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Control
    {

        [System.Text.Json.Serialization.JsonPropertyName("Type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public ControlType Type { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Name { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Font")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public Font Font { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Cell")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public Cell Cell { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("PlaceholderText")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string PlaceholderText { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("TextAlign")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public TextAlign TextAlign { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Font
    {

        [System.Text.Json.Serialization.JsonPropertyName("Name")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public FontName Name { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Size")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int Size { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Bold")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool Bold { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public enum TextAlign
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Left")]
        Left = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Right")]
        Right = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"TopLeft")]
        TopLeft = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"TopCenter")]
        TopCenter = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"TopRight")]
        TopRight = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"MiddleLeft")]
        MiddleLeft = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"MiddleCenter")]
        MiddleCenter = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"MiddleRight")]
        MiddleRight = 7,


        [System.Runtime.Serialization.EnumMember(Value = @"BottomLeft")]
        BottomLeft = 8,


        [System.Runtime.Serialization.EnumMember(Value = @"BottomCenter")]
        BottomCenter = 9,


        [System.Runtime.Serialization.EnumMember(Value = @"BottomRight")]
        BottomRight = 10,


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Cell
    {

        [System.Text.Json.Serialization.JsonPropertyName("Row")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int Row { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Column")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int Column { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public enum ControlType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Label")]
        Label = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"TextBox")]
        TextBox = 1,


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Anonymous4
    {

        [System.Text.Json.Serialization.JsonPropertyName("type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Type { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Font")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public Font Font { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("Cell")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public Cell Cell { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("TextAlign")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string TextAlign { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("PlaceholderText")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string PlaceholderText { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Anonymous5
    {

        [System.Text.Json.Serialization.JsonPropertyName("control")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public Control Control { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public partial class Sample
    {

        [System.Text.Json.Serialization.JsonPropertyName("$schema")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string Schema { get; set; }


        [System.Text.Json.Serialization.JsonPropertyName("controls")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.ICollection<Anonymous5> Controls { get; set; }



        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v13.0.1.0)")]
    public enum FontName
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Arial")]
        Arial = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Consolas")]
        Consolas = 1,


    }
}