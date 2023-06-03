$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetList();
});

function GetList() {
    var grid = $(requestGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "/Request/GetList",
            insertUrl: "/Request/RequestAdd",
            updateUrl: "/Request/RequestEdit",
            deleteUrl: "/Request/RequestDelete",
            onBeforeSend: function (method, ajaxOptions) {
                ajaxOptions.xhrFields = { withCredentials: true };
            }
        }),
        onCellPrepared(e) {
            if (e.rowType == "header") {
                e.cellElement.css("text-align", "center");
            }
        },
        onRowPrepared: function (e) {
            if (e.rowType == "header") { e.rowElement.css("background-color", "#b9ceff"); e.rowElement.css('color', '#4f5052'); e.rowElement.css('font-weight', 'bold'); };
        },
        rowAlternationEnabled: true,
        grouping: {
            contextMenuEnabled: true
        },
        groupPanel: {
            visible: true   // or "auto"
        },

        columnAutoWidth: true,
        remoteOperations: true,
        allowColumnReordering: true,
        showBorders: true,
        
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: 'Ara...',
        },
        headerFilter: {
            visible: true,
        },
        paging: { enabled: true },
        height: "100%",
        pager: {
            visible: true,
            allowedPageSizes: [10, 20, 50],
            showPageSizeSelector: true,
            showInfo: true,
            showNavigationButtons: true,
        },
        onEditingStart: function (e) {
            title = e.data.Date;
        },
        onInitNewRow: function (e) {
            title = "";
        },

        loadPanel: {
            enabled: true,
        },
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true,
            popup: {
                title: 'Ekle',
                showTitle: true,
                width: 500,
                height: 325,
            },
            form: {
                items: [{
                    itemType: 'group',
                    colCount: 2,
                    colSpan: 2,
                    items: [
                        {
                            dataField: "requestName",
                            caption: "Talep Adı",
                        },
                        {
                            dataField: "description",
                            caption: "Açıklama",
                        },
                    ],
                }],

            },

        },

        columns: [

            {
                dataField: "requestName",
                caption: "Talep Adı",
                alignment: 'center',
            },
            {
                dataField: "description",
                caption: "Açıklama",
                alignment: 'center',
            },
           
            {
                type: "buttons",
                buttons: ["edit", "delete"]
            },
        ],

    }).dxDataGrid("instance");

}

