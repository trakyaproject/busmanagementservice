<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Station.aspx.cs" Inherits="Client_Station" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager  runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <div>
         
        <ext:Hidden runat="server" ID="hdnStationType"></ext:Hidden>
        <ext:GridPanel ID="grdStation" runat="server"  AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                 <ext:Button runat="server" ID="btnAddNew" Text="Yeni Durak Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">
                 </ext:Button>
                    <ext:Button ID="btnGetAccounts" runat="server" Icon="Find" OnDirectClick="btnGetAccounts_DirectClick" Text="Listele">
                        <DirectEvents>
                            <Click Timeout="2000000">
                                <EventMask Msg="Kayıtlar Getiriliyor. Lütfen bekleyiniz..." ShowMask="true"></EventMask>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                 </Items>
            </ext:Toolbar>
        </TopBar>

        <Store>
            <ext:Store runat="server" ItemID="ID">
                <Model>
                    <ext:Model runat="server" IDProperty="stationId">
                        <Fields>
                            <ext:ModelField Name="stationId"></ext:ModelField>
                            <ext:ModelField  Name="stationName"></ext:ModelField>
                             <ext:ModelField Name="location"></ext:ModelField>
                            <ext:ModelField Name="address"></ext:ModelField>
                            <ext:ModelField Name="state"></ext:ModelField>
                            <ext:ModelField Name="createdAt"></ext:ModelField>
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel  runat="server">
            <Columns>
                <ext:RowNumbererColumn runat="server"  Text="Sıra No" Width="80"></ext:RowNumbererColumn>
                 <ext:Column runat="server" DataIndex="stationId" Flex="2" Visible="false" Text="" ></ext:Column>
                <ext:Column  runat="server" DataIndex="stationName" Flex="2" Text="Durak Adı" ></ext:Column>
                <ext:Column runat="server" DataIndex="location" Flex="2" Text="Konum"></ext:Column>
                <ext:Column runat="server" DataIndex="address" Flex="2" Text="Adres"></ext:Column>
                <ext:Column runat="server" DataIndex="state" Flex="2" Text="Durum"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="createdAt" Flex="2" Text="Tarih"></ext:DateColumn>
                    <ext:CommandColumn runat="server" Width="300">
                    <Commands>
                        <ext:GridCommand CommandName="cmdDel" Icon="Delete" Text="Sil"></ext:GridCommand>
                        <ext:GridCommand CommandName="cmdUpdate" Icon="ApplicationEdit" Text="Güncelle"></ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="cmdCommand">
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="stationId" Value="record.data.stationId"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="stationName" Value="record.data.stationName"></ext:Parameter>
                            </ExtraParams>
                            <EventMask Msg="Bilgiler getiriliyor...Lütfen Bekleyiniz.." ShowMask="true"></EventMask>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        </ext:GridPanel>
        
         <ext:Window ID="Window1" 
            runat="server" 
            Width="600"
            Modal="true"
            Hidden="true"          
            BodyPadding="5"
            Layout="FormLayout">           
            <Items>
                 <ext:TextField ID="txtstationId" runat="server"  FieldLabel="Sıra No" ReadOnly="true" Visible="true" AllowBlank="false"/>
                <ext:TextField ID="txtstationName" runat="server" FieldLabel="Durak Adı" AllowBlank="false"/>
                <ext:TextField  ID="txtlocation" runat="server" FieldLabel="Konum" AllowBlank="false" />
                <ext:TextField  ID="txtaddress" runat="server" FieldLabel="Adres" AllowBlank="false">
                 <RightButtons>
                        <ext:Button runat="server" ID="Add" Text="Kaydet" OnDirectClick="btnKaydet_DirectClick">
                           <DirectEvents>
                               <Click>
                                   <EventMask ShowMask="true" Msg="Kayıt ediliyor."></EventMask>
                               </Click>
                           </DirectEvents>
                        </ext:Button>
                    </RightButtons>
                </ext:TextField>
            </Items>            
        </ext:Window>     
          <ext:Window runat="server" ID="wndDeleteConfirm" Title="Silme Onayı" Modal="true" Hidden="true" Width="300"  Height="100" BodyStyle="background-color:white;">
            
              <Items>
                  
                <ext:Hidden runat="server" ID="hdnStationDelete"></ext:Hidden>
                <ext:Label runat="server" ID="lblDeleteConfim" HTML="silmek istediğinizden <b>emin misiniz?</b>"></ext:Label>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDeleteConfirmSave" OnDirectClick="btnDel_DirectClick" Text="Sil" Icon="DatabaseDelete"></ext:Button>
                <ext:Button runat="server" ID="btnDeleteConfirmCancel" OnDirectClick="btnExit_DirectClick" Text="Vazgeç" Icon="Cancel"></ext:Button>
            </Buttons>
        </ext:Window>       

    </div>
    </form>
</body>
</html>
