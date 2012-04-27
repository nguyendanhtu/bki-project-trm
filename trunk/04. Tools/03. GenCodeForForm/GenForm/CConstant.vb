Namespace CommonSpace
    Public Class CConstant
        Public Class Cpath
            Public Const COMMENT As String = "\TemplatesCsharp\Comment.txt"
            Public Const IMPORT As String = "\TemplatesCsharp\Import.txt"
            Public Const CREATE_FORM As String = "\TemplatesCsharp\CreateForm.txt"
            Public Const LSEND As String = "\TemplatesCsharp\CLSEnd.txt"
            Public Const REGION_PUBLIC_INTERFACE As String = "\TemplatesCsharp\RegionPublicInterface.txt"
            Public Const REGION_DATA_STRUCTURE As String = "\TemplatesCsharp\RegionDataStructure.txt"
            Public Const REGION_MEMBERS As String = "\TemplatesCsharp\RegionMembers.txt"
            Public Const REGION_PRIVATE_METHODS As String = "\TemplatesCsharp\RegionPrivateMethods.txt"
            Public Const REGION_EVENTS As String = "\TemplatesCsharp\RegionEvents.txt"
            Public Const COLLECTION_OF_FORM As String = "\TemplatesCsharp\CollectionOfForm.txt"
        End Class
        Public Class CKeyToReplace
            Public Const CREATED_USER As String = "<NGUOI_TAO>"
            Public Const CREATED_DATE As String = "<DATE>"
            Public Const U_TABLE_NAME As String = "<U/TABLE_NAME>"
            Public Const L_TABLE_NAME As String = "<L/TABLE_NAME>"
            Public Const FORM_NAME As String = "<FORM_NAME>"
            Public Const NUM_OF_COLS As String = "<NUM_OF_COLS>"
            Public Const COLUMN_LIST_TO_DISPLAY As String = "<COLUMN_LIST_TO_DISPLAY>"
            Public Const COLS_INFO As String = "<COLS_INFO>"
        End Class
        Public Class CGridCol
            Public Const TEMPLATE_COL As String = "<NUM_COL>{Caption:""""<CAPTION>"""";Visible:<VISIBLE_ENUM>;DataType:<DATA_TYPE_ENUM>;TextAlign:<TEXT_ALIGN_ENUM>;TextAlignFixed:<TEXT_ALIGN_FIXED_ENUM>;}"
            Public Class TEMPLATE_COL_INFO
                Public Const NUM_COL As String = "<NUM_COL>"
                Public Const CAPTION As String = "<CAPTION>"
                Public Const DATA_TYPE_ENUM As String = "<DATA_TYPE_ENUM>"
                Public Const TEXT_ALIGN_ENUM As String = "<TEXT_ALIGN_ENUM>"
                Public Const TEXT_ALIGN_FIXED_ENUM As String = "<TEXT_ALIGN_FIXED_ENUM>"
                Public Const VISIBLE_ENUM As String = "<VISIBLE_ENUM>"
            End Class
        End Class
    End Class
End Namespace

