<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Station.aspx.cs" Inherits="Client_Station" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <div>
   
        <ext:Hidden runat="server" ID="hdnStationType"></ext:Hidden>
        <ext:GridPanel ID="grdStation" runat="server" Title="Durak Listesi" AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddNew" Text="Yeni Durak Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">

                    </ext:Button>
                    <ext:Button ID="btnGetList" runat="server" Icon="Find" OnDirectClick="btnGetList_DirectClick" Text="Listele">
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
            <ext:Store ID="Store2" runat="server" ItemID="ID">
                <Model>
                    <ext:Model ID="Model2" runat="server" IDProperty="ID">
                        <Fields>
                            <ext:ModelField Name="stationId"></ext:ModelField>
                            <ext:ModelField Name="stationName"></ext:ModelField>
                            <ext:ModelField Name="location"></ext:ModelField>
                            <ext:ModelField Name="address"></ext:ModelField>
                            <%--<ext:ModelField Name="Note"></ext:ModelField>--%>
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel2" runat="server">
            <Columns>
                <ext:RowNumbererColumn ID="RowNumbererColumn2" runat="server"  Width="80"></ext:RowNumbererColumn>
                <ext:Column ID="Column1" runat="server" DataIndex="stationName" Text="Durak Adı" Flex="4"></ext:Column>
                <ext:Column ID="Column2" runat="server" DataIndex="location" Text="Hat No" Flex="4"></ext:Column>
                <ext:Column ID="Column3" runat="server" DataIndex="address" Text="Adres" Flex="4"></ext:Column>
                <%--<ext:Column ID="Column4" runat="server" DataIndex="Note" Text="Not" Flex="4"></ext:Column>--%>
            </Columns>
        </ColumnModel>
        </ext:GridPanel>
        <ext:Window runat="server" ID="wndNew" Title="Yeni İşlem" Modal="true" Hidden="true" Width="400" Height="175" Padding="5" BodyStyle="background-color:white;">
            <Items>
                <ext:ComboBox runat="server" ID="cbAccount" FieldLabel="Durak" DisplayField="AccountNumber" ValueField="CardID" Padding="10">
                    <Store>
                        <ext:Store ID="Store3" runat="server">
                            <Fields>
                            <ext:ModelField Name="stationId"></ext:ModelField>
                                <ext:ModelField Name="stationName"></ext:ModelField>
                                <ext:ModelField Name="location"></ext:ModelField>
                            <ext:ModelField Name="address"></ext:ModelField>
                            <%--<ext:ModelField Name="Note"></ext:ModelField>--%>
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
              </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnSave" Text="Kaydet" Icon="DatabaseSave" OnDirectClick="btnSave_DirectClick">
                    <DirectEvents>
                        <Click>
                            <EventMask ShowMask="true" Msg="Kayıt ediliyor.. "></EventMask>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Text="Vazgeç" Icon="Delete" OnDirectClick="btnCancel_DirectClick"></ext:Button>
            </Buttons>
        </ext:Window>
         <ext:Window ID="Window1" 
            runat="server" 
            Width="600"
            CloseAction = "Hide"          
            Closable="true"
            BodyPadding="5"
            Layout="FormLayout"
          Visible="false">           
            <Items>
               
                <ext:TextField ID="txtStationName" runat="server" FieldLabel="Durak Adı" AllowBlank="false"/>
                <ext:TextField  ID="txtStationno" runat="server" FieldLabel="Hat No" AllowBlank="false" />
                <ext:TextField ID="TextAddress" runat="server" FieldLabel="Adres" AllowBlank="false">
              <%--  <ext:TextField ID="TextNote" runat="server" FieldLabel="Not" AllowBlank="false">--%>
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
    </div>
    </form>
</body>
</html>
