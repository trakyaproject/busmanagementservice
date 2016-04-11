<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShiftTime.aspx.cs" Inherits="Client_ShiftTime" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>

   <%-- <link href="/resources/css/examples.css" rel="stylesheet" />--%>

    <script>
        /* A header Checkbox of CheckboxSelectionModel deals with the current page only.
           This override demonstrates how to take into account all the pages.
           It works with local paging only. It is not going to work with remote paging.
        */
        Ext.selection.CheckboxModel.override({
            selectAll: function (suppressEvent) {
                var me = this,
                    selections = me.store.getAllRange(), // instead of the getRange call
                    i = 0,
                    len = selections.length,
                    start = me.getSelection().length;

                me.suspendChanges();

                for (; i < len; i++) {
                    me.doSelect(selections[i], true, suppressEvent);
                }

                me.resumeChanges();
                if (!suppressEvent) {
                    me.maybeFireSelectionChange(me.getSelection().length !== start);
                }
            },

            deselectAll: Ext.Function.createSequence(Ext.selection.CheckboxModel.prototype.deselectAll, function () {
                this.view.panel.getSelectionMemory().clearMemory();
            }),

            updateHeaderState: function () {
                var me = this,
                    store = me.store,
                    storeCount = store.getTotalCount(),
                    views = me.views,
                    hdSelectStatus = false,
                    selectedCount = 0,
                    selected, len, i;

                if (!store.buffered && storeCount > 0) {
                    selected = me.view.panel.getSelectionMemory().selectedIds;
                    hdSelectStatus = true;
                    for (s in selected) {
                        ++selectedCount;
                    }

                    hdSelectStatus = storeCount === selectedCount;
                }

                if (views && views.length) {
                    me.toggleUiHeader(hdSelectStatus);
                }
            }
        });

        Ext.grid.plugin.SelectionMemory.override({
            memoryRestoreState: function (records) {
                if (this.store !== null && !this.store.buffered && !this.grid.view.bufferedRenderer) {
                    var i = 0,
                        ind,
                        sel = [],
                        len,
                        all = true,
                        cm = this.headerCt;

                    if (!records) {
                        records = this.store.getAllRange(); // instead of getRange
                    }

                    if (!Ext.isArray(records)) {
                        records = [records];
                    }

                    if (this.selModel.isLocked()) {
                        this.wasLocked = true;
                        this.selModel.setLocked(false);
                    }

                    if (this.selModel instanceof Ext.selection.RowModel) {
                        for (ind = 0, len = records.length; ind < len; ind++) {
                            var rec = records[ind],
                                id = rec.getId();

                            if ((id || id === 0) && !Ext.isEmpty(this.selectedIds[id])) {
                                sel.push(rec);
                            } else {
                                all = false;
                            }

                            ++i;
                        }

                        if (sel.length > 0) {
                            this.surpressDeselection = true;
                            this.selModel.select(sel, false, !this.grid.selectionMemoryEvents);
                            this.surpressDeselection = false;
                        }
                    } else {
                        for (ind = 0, len = records.length; ind < len; ind++) {
                            var rec = records[ind],
                                id = rec.getId();

                            if ((id || id === 0) && !Ext.isEmpty(this.selectedIds[id])) {
                                if (this.selectedIds[id].dataIndex) {
                                    var colIndex = cm.getHeaderIndex(cm.down('gridcolumn[dataIndex=' + this.selectedIds[id].dataIndex + ']'))
                                    this.selModel.setCurrentPosition({
                                        row: i,
                                        column: colIndex
                                    });
                                }
                                return false;
                            }

                            ++i;
                        }
                    }

                    if (this.selModel instanceof Ext.selection.CheckboxModel) {
                        if (all && (records.length > 0)) {
                            this.selModel.toggleUiHeader(true);
                        } else {
                            this.selModel.toggleUiHeader(false);
                        }
                    }

                    if (this.wasLocked) {
                        this.selModel.setLocked(true);
                    }
                }
            }
        });
    </script>

<%--    <script>
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return Ext.String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return Ext.String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
    </script>--%>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
            <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            Title="Vardiyalar"
            Collapsible="true"
            Width="600">
            <Store>
                <ext:Store ID="Store1" runat="server" PageSize="10">
                    <Model>
                        <ext:Model runat="server" IDProperty="shiftTimeId">
                            <Fields>
                                <ext:ModelField Name="shiftTimeId" />
                                <ext:ModelField Name="departureTime" />
                                <ext:ModelField Name="plate" />
                                <ext:ModelField Name="driverId" />
                                <ext:ModelField Name="lineId" />
                                 <ext:ModelField Name="stiftStart" />
                                <ext:ModelField Name="shiftEnd" />
                                <ext:ModelField Name="state" />
                                <ext:ModelField Name="createdAt" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column
                        runat="server"
                        Text="Company"
                        Width="160"
                        DataIndex="Name"
                        Resizable="false"
                        MenuDisabled="true"
                        Flex="1" />

                     <ext:Column runat="server" Text="" Width="75" DataIndex="shiftTimeId" Visible="false"></ext:Column>
                     <ext:Column runat="server" Text="Kalkış Saati" Width="75" DataIndex="departureTime"></ext:Column>
                     <ext:Column runat="server" Text="Price" Width="75" DataIndex="plate"></ext:Column>
                     <ext:Column runat="server" Text="" Width="75" DataIndex="driverId" Visible="false"></ext:Column>
                     <ext:Column runat="server" Text="" Width="75" DataIndex="lineId" Visible="false"></ext:Column>
                     <ext:Column runat="server" Text="Başlangıç Saati" Width="75" DataIndex="stiftStart"></ext:Column>
                     <ext:Column runat="server" Text="Bitiş Saati" Width="75" DataIndex="shiftEnd"></ext:Column>
                     <ext:Column runat="server" Text="Durum" Width="75" DataIndex="state"></ext:Column>
                     <ext:Column runat="server" Text="Tarih" Width="75" DataIndex="createdAt"></ext:Column>

                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CheckboxSelectionModel runat="server" Mode="Multi" />
            </SelectionModel>
        </ext:GridPanel>
     </form>
  </body>
</html>