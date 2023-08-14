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
            deleteUrl: "/Request/RequestDelete/",
            onBeforeSend: function (method, ajaxOptions) {
                ajaxOptions.xhrFields = { withCredentials: true };
            }
        }),
        editing: {
            mode: 'row',
            allowUpdating: true,
            allowDeleting: true,
        },
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
        onContentReady: function (e) {

            var $refreshButton = $('<div id="refreshButton">').dxButton({
                icon: 'refresh',
                onClick: function () {
                    grid.refresh();
                }
            });
            if (e.element.find('#refreshButton').length == 0)
                e.element
                    .find('.dx-toolbar-after')
                    .prepend($refreshButton);

            var $filterButton = $('<div id="filterButton">').dxButton({
                icon: 'clearformat',
                onClick: function () {
                    grid.clearFilter();
                }
            });
            if (e.element.find('#filterButton').length == 0)
                e.element
                    .find('.dx-toolbar-after')
                    .prepend($filterButton);


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
                        {
                            dataField: "categoryStatus",
                            caption: "Kategori",
                            lookup: {
                                dataSource: DevExpress.data.AspNet.createStore({
                                    key: "iD",
                                    loadUrl: "/Request/GetCategoryStatus/",
                                    onBeforeSend: function (method, ajaxOptions) {
                                        ajaxOptions.xhrFields = { withCredentials: true, };
                                    },
                                }),
                                valueExpr: "Id",
                                displayExpr: "Text",
                            }
                        },
                        {
                            dataField: "customerID",
                            caption: "Müşteri Adı",
                            alignment: 'center',
                            lookup: {
                                dataSource: DevExpress.data.AspNet.createStore({
                                    key: "Id",
                                    loadUrl: "/Request/GetCustomer/",
                                    onBeforeSend: function (method, ajaxOptions) {
                                        ajaxOptions.xhrFields = { withCredentials: true, };
                                    },
                                }),
                                valueExpr: "id",
                                displayExpr: "name",
                            }
                        },
                        {
                            dataField: "projectID",
                            caption: "Proje",
                            lookup: {
                                dataSource: DevExpress.data.AspNet.createStore({
                                    key: "Id",
                                    loadUrl: "/Request/GetProject/",
                                    onBeforeSend: function (method, ajaxOptions) {
                                        ajaxOptions.xhrFields = { withCredentials: true, };
                                    },
                                }),
                                valueExpr: "id",
                                displayExpr: "name",
                            }
                        }
                    ],
                }],

            },

        },

        columns: [

            {
                dataField: "ProjectID",
                caption: "Proje",
                alignment: 'center',
            },
            {
                dataField: "ModulesID",
                caption: "Modül",
                alignment: 'center',
            },
            {
                dataField: "CustomerID",
                caption: "Müşteri",
                alignment: 'center',
            },
            {
                dataField: "NotificationType",
                caption: "Bildirim Türü",
                alignment: 'center',
            },
            {
                dataField: "requestSubject",
                caption: "Konu",
                alignment: 'center',
            },
            {
                dataField: "description",
                caption: "Açıklama",
                alignment: 'center',
            },
            {
                dataField: "PageURL",
                caption: "Sayfa Linki",
                alignment: 'center',
            },
            {
                dataField: "Category",
                caption: "Kategori",
                alignment: 'center',
            },
            {
                dataField: "PictureURL",
                caption: "Görüntü",
                alignment: 'center',
            },
            {
                dataField: "categoryStatus",
                caption: "Kategori",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "ID",
                        loadUrl: "/Request/GetCategoryStatus/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "Id",
                    displayExpr: "Text",
                }
            },
            {
                dataField: "customerID",
                caption: "Müşteri Adı",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Request/GetCustomer/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "name",
                }
            },
            {
                dataField: "projectID",
                caption: "Proje",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Request/GetProject/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "name",
                }
            },

        ],
        masterDetail: {
            enabled: true,
            template: function (container, options) {
                return $("<div>")
                    .dxDataGrid({
                        columnAutoWidth: true,
                        showBorders: true,
                        showColumnLines: true,
                        showRowLines: true,
                        rowAlternationEnabled: true,
                        allowColumnReordering: true,
                        onRowPrepared: function (e) {
                            if (e.rowType == "header") { e.rowElement.css("background-color", "#fcfae3"); e.rowElement.css('color', '#4f5052'); };
                        },
                        onEditingStart(e) {
                            title = e.data.ElementDescription;
                        },
                        onInitNewRow: function (e) {
                            title = "";
                        },
                        onInitialized: function (e) {
                            actionGridContainer = e.component;
                        },
                        editing: {
                            mode: 'row',
                            allowAdding: true,
                            allowUpdating: true,
                            allowDeleting: true,
                        },
                        columns: [
                            {
                                dataField: "id",
                                caption: "Aksiyon No",
                                alignment: 'center',
                                allowEditing: false,
                            },
                            {
                                dataField: "actionDescription",
                                caption: "Aksiyon Açıklaması",
                                alignment: 'left',
                            },
                            {
                                dataField: "responsibleID",
                                caption: "Sorumlu",
                                alignment: 'center',
                                lookup: {
                                    dataSource: DevExpress.data.AspNet.createStore({
                                        loadUrl: "/Action/GetResponsible/",
                                    }),
                                    valueExpr: "id", 
                                    displayExpr: "name"
                                }
                            },
                            {
                                dataField: "openingDate",
                                caption: "Açılma Tarihi",
                                alignment: 'center',
                                dataType: 'date',
                                format: 'dd/MM/yyyy',
                            },
                            {
                                dataField: "endDate",
                                caption: "Son Tarih",
                                alignment: 'left',
                                dataType: 'date',
                                format: 'dd/MM/yyyy',
                            },
                            {
                                dataField: "description",
                                caption: "Açıklama",
                                alignment: 'left',
                            },
                            {
                                dataField: "actionStatus",
                                caption: "Durum",
                                alignment: 'center',
                                lookup: {
                                    dataSource: DevExpress.data.AspNet.createStore({
                                        key: "Id",
                                        loadUrl: "/Action/GetActionStatus",
                                        onBeforeSend: function (method, ajaxoptions) {
                                            ajaxoptions.xhrFields = { withCredentials: true };
                                        },
                                    }),
                                    valueExpr: "Id",
                                    displayExpr: "Text"
                                }
                            }
                        ],
                        dataSource: DevExpress.data.AspNet.createStore({
                            key: "id",
                            loadUrl: "/Request/GetRequestDetail/",
                            loadParams: { ID: options.data.id },
                            updateUrl: "/Request/EditActionItem/" ,
                            insertUrl: "/Request/AddActionItem/",
                            deleteUrl:"/Request/DeleteActionItem/",
                            onBeforeSend: function (method, ajaxoptions) {
                                ajaxoptions.data.id = options.data.id;
                                ajaxoptions.xhrFields = { withCredentials: true };
                            }
                        })
                    })
            }
        }

    }).dxDataGrid("instance");

}

function deleteRequestAsk(id) {
    DeleteDialog("RequestDelete", id, "Talep Silinecektir!");
}

function DeleteDialog(id) {

    var data = new FormData();

    data.append('id', id);

    $.ajax({
        url: "/Request/RequestDelete/",
        type: 'POST',
        async: false,
        data: data,
        cache: false,
        processData: false,
        contentType: false,
        success: function (data2) {
            if (data2 > 0) {
                messah("Başarılı", "Firma Silindi", "success");
                location.reload();
            }
            else {
                ShowToastr("Hata", "Bir Hata Oluştu", "error");
            }
        },
        error: function (textStatus) {
            console.log('ERRORS:23 ');
        },
    });
}
