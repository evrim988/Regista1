$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetModules();
});
function GetModules() {
    var grid = $(modulesGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "ID",
            loadUrl: "/Modules/GetModules",
            insertUrl: "/Modules/AddModules",
            updateUrl: "/Modules/ModulesUpdate",
            deleteUrl: "/Modules/DeleteModules",
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
            if (e.rowType == "header") { e.rowElement.css("background-color", "#dff0f7"); e.rowElement.css('color', '#4f5052'); e.rowElement.css('font-weight', 'bold'); };
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
        export: {
            enabled: true
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
                            dataField: "name",
                            caption: "Adı",
                        },
                        {
                            dataField: "description",
                            caption: "Açıklama",
                        },
                    ],
                }],

            },

        },

        onContentReady: function (e) {

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

        columns: [
            {
                dataField: "name",
                caption: "Adı",
                alignment: 'center',
            },
            {
                dataField: "description",
                caption: "Açıklama",
                alignment: 'center',
            },

        ],

    }).dxDataGrid("instance");

}
