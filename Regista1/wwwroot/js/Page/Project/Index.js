$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetList();

});

function GetList() {
    var grid = $(projectGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "/Project/GetList",
            //insertUrl: "/Customer/CreateCustomer",
            //updateUrl: "/Customer/EditCustomer",
            //deleteUrl: "/Customer/DeleteCustomer",
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
        //onToolbarPreparing: function (e) {
        //    let toolbarItems = e.toolbarOptions.items;
        //    toolbarItems.push({
        //        widget: "dxButton",
        //        options: {
        //            icon: "add", text: "Yeni Müşteri", onClick: function () {
        //                loadUrl: "customer/Add",
        //                    $('#confirmeModal').modal();
        //            }
        //        },

        //        location: "after",


        //    });
        //},
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
        filterRow: {
            visible: true,
        },
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
        //editing: {
        //    mode: 'popup',
        //    allowUpdating: true,
        //    allowDeleting: true,
        //    allowAdding: true,
        //    popup: {
        //        title: 'Ekle',
        //        showTitle: true,
        //        width: 500,
        //        height: 325,
        //    },
        //    form: {
        //        items: [{
        //            itemType: 'group',
        //            colCount: 2,
        //            colSpan: 2,
        //            items: [
        //                {
        //                    dataField: "Name",
        //                    caption: "Firma Adı",
        //                },
        //                {
        //                    dataField: "TaxNumber",
        //                    caption: "Vergi Numarası",
        //                },
        //            ],
        //        }],

        //    },

        //},



        columns: [

            {
                dataField: "ProjectName",
                caption: "Proje Adı",
                alignment: 'center',
            },
            {
                dataField: "ProjectDescription",
                caption: "Proje Açıklaması",
                alignment: 'center',
            },
            //{
            //    type: "buttons",
            //    buttons: ["edit", "delete",

            //        {
            //            hint: "Detay",
            //            icon: "edit",
            //            onClick: function (e) {
            //                location.href = '../../Customer/EditCustomer/' + e.row.data.id;
            //            }
            //        },
            //        {
            //            hint: "Sil",
            //            icon: "remove",
            //            onClick: function (e) {
            //                deleteCustomerAsk(e.row.data.id);
            //            }
            //        },

            //    ]

            //},
        ],

    }).dxDataGrid("instance");

}
