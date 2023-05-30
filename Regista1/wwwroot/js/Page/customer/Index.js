$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetList();

});

function GetList() {
    var grid = $(customersGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "/Customer/GetList",
            insertUrl: "/Customer/Add",
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
        
        editing: {
            mode: 'popup',
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true,
            popup: {
                title: 'Yeni Müşteri Ekle',
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
                            dataField: "Name",
                            caption: "Müşteri Adı",
                        },
                        {
                            dataField: "Surname",
                            caption: "Müşteri Soyadı",
                        },
                        {
                            dataField: "Adress",
                            caption: "Adres",
                        },
                        {
                            dataField: "FirmaAdı",
                            caption: "Firma Adı",
                        },
                        {
                            dataField: "EMail",
                            caption: "EMail",
                        },
                    ],
                }],

            },

        },


        columns: [

            {
                dataField: "Name",
                caption: "Müşteri Adı",
                alignment: 'center',
            },
            {
                dataField: "Surname",
                caption: "Müşteri Soyadı",
                alignment: 'center',
            },
            {
                dataField: "Adress",
                caption: "Adres",
                alignment: 'center',
            },
            {
                dataField: "FirmaAdı",
                caption: "Firma Adı",
                alignment: 'center',
            },
            {
                dataField: "EMail",
                caption: "EMail",
                alignment: 'center',
            },
            {
                type: "buttons",
                buttons: ["edit", "delete",

                    {
                        hint: "Detay",
                        icon: "edit",
                        onClick: function (e) {
                            location.href = '../../Customer/EditCustomer/' + e.row.data.id;
                        }
                    },
                    {
                        hint: "Sil",
                        icon: "remove",
                        onClick: function (e) {
                            deleteCustomerAsk(e.row.data.id);
                        }
                    },

                ]

            },
        ],

    }).dxDataGrid("instance");

}

//function deleteCustomerAsk(ID) {
//    DeleteDialog("DeleteCustomer", ID, "Firma Silinecektir!");
//}

//function DeleteCustomer(ID) {

//    var data = new FormData();

//    data.append('ID', ID);

//    $.ajax({
//        url: "/Customer/DeleteCustomer/",
//        type: 'POST',
//        async: false,
//        data: data,
//        cache: false,
//        processData: false,
//        contentType: false,
//        success: function (data2) {
//            if (data2 > 0) {
//                ShowToastr("Başarılı", "Firma Silindi", "success");
//                location.reload();
//            }
//            else {
//                ShowToastr("Hata", "Bir Hata Oluştu", "error");
//            }
//        },
//        error: function (textStatus) {
//            console.log('ERRORS:23 ');
//        },
//    });
//}