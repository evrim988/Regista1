﻿$(document).ready(function () {
    DevExpress.localization.locale('tr');
    GetList();
});

function GetList() {
    var grid = $(tasksGridContainer).dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "/Task/GetList",
            //insertUrl: "/Task/AddTask",
            updateUrl: "/Task/TaskUpdate",
            deleteUrl: "/Task/Delete",
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
            mode: 'row',
            allowUpdating: true,
            allowDeleting: true,
        },
        //editing: {
        //    mode: 'popup',
        //    allowUpdating: true,
        //    allowDeleting: true,
        //    allowAdding: true,
        //    popup: {
        //        title: 'Yeni Görev Ekle',
        //        showTitle: true,
        //        width: 800,
        //        height: 350,
        //    },
        //    form: {
        //        items: [{
        //            itemType: 'group',
        //            colCount: 2,
        //            colSpan: 2,
        //            items: [
        //                {
        //                    dataField: "planedStart",
        //                    caption: "Planlanan Başlangıç Tarihi",
        //                    dataType: 'date',
        //                    format: 'dd/MM/yyyy',
        //                },
        //                {
        //                    dataField: "title",
        //                    caption: "Konu",
        //                },
        //                {
        //                    dataField: "description",
        //                    caption: "Açıklama",
        //                },
        //                {
        //                    dataField: "responsibleID",
        //                    caption: "Sorumlu",
        //                    lookup: {
        //                        dataSource: DevExpress.data.AspNet.createStore({
        //                            key: "Id",
        //                            loadUrl: "/Task/GetResponsible/",
        //                            onBeforeSend: function (method, ajaxOptions) {
        //                                ajaxOptions.xhrFields = { withCredentials: true, };
        //                            },
        //                        }),
        //                        valueExpr: "id",
        //                        displayExpr: "name",
        //                    }
        //                },
        //                {
        //                    dataField: "taskStatus",
        //                    caption: "Durum",
        //                    lookup: {
        //                        dataSource: DevExpress.data.AspNet.createStore({
        //                            key: "iD",
        //                            loadUrl: "/Task/GetTaskStatus/",
        //                            onBeforeSend: function (method, ajaxOptions) {
        //                                ajaxOptions.xhrFields = { withCredentials: true, };
        //                            },
        //                        }),
        //                        valueExpr: "Id",
        //                        displayExpr: "Text",
        //                    }
        //                },
        //                {
        //                    dataField: "priorityStatus",
        //                    caption: "Öncelik",
        //                    lookup: {
        //                        dataSource: DevExpress.data.AspNet.createStore({
        //                            key: "Id",
        //                            loadUrl: "/Task/GetPriorityStatus/",
        //                            onBeforeSend: function (method, ajaxOptions) {
        //                                ajaxOptions.xhrFields = { withCredentials: true, };
        //                            },
        //                        }),
        //                        valueExpr: "Id",
        //                        displayExpr: "Text",
        //                    }
        //                },
                        
        //            ],
        //        }],

        //    },

        //},
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
        columns: [

            {
                dataField: "id",
                caption: "No",
                alignment: 'center',
            },
            {
                dataField: "planedStart",
                caption: "Planlanan Başlangıç Tarihi",
                alignment: 'center',
                dataType: 'date',
                format: 'dd/MM/yyyy',
            },
            {
                dataField: "planedEnd",
                caption: "Planlanan Bitiş Tarihi",
                alignment: 'center',
                dataType: 'date',
                format: 'dd/MM/yyyy',
            },
            {
                dataField: "title",
                caption: "Konu",
                alignment: 'center',
            },
            {
                dataField: "description",
                caption: "Açıklama",
                alignment: 'center',
            },
            {
                dataField: "responsibleID",
                caption: "Sorumlu",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Task/GetResponsible/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "name",
                }
            },
            {
                dataField: "taskStatus",
                caption: "Durum",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Task/GetTaskStatus/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "Text",
                }
            },
            {
                dataField: "priorityStatus",
                caption: "Öncelik",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Task/GetPriorityStatus/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "Text",
                }
            },
            {
                dataField: "requestID",
                caption: "Talep Adı",
                alignment: 'center',
                lookup: {
                    dataSource: DevExpress.data.AspNet.createStore({
                        key: "Id",
                        loadUrl: "/Task/GetRequest/",
                        onBeforeSend: function (method, ajaxOptions) {
                            ajaxOptions.xhrFields = { withCredentials: true, };
                        },
                    }),
                    valueExpr: "id",
                    displayExpr: "name",
                }
            },
            {
                caption: "İşlemler",
                type: "buttons",
                fixed: true,
                fixedPosition: "right",
                buttons: ["edit", "delete"]
            },
        ],

    }).dxDataGrid("instance");

}

