$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetList();
});

function GetList() {
    var grid = $(actionsGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "/Home/GetActionHome",
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
            visible: true
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

        columns: [
            {
                dataField: "id",
                caption: "Aksiyon No",
                alignment: 'center',
            },
            {
                dataField: "ActionDescription",
                caption: "Aksiyon Açıklaması",
                alignment: 'left',
            },
            {
                dataField: "ResponsibleID",
                caption: "Sorumlu",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "id",
                        loadUrl: "/Action/GetResponsible/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true };
                        }
                    }),
                    valueExpr: "Id",
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

    }).dxDataGrid("instance");

}

