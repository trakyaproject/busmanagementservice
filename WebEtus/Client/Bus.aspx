<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bus.aspx.cs" Inherits="Client_Bus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager  runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <div>
         
        <ext:Hidden runat="server" ID="hdnBusType"></ext:Hidden>
        <ext:GridPanel ID="grdBus" runat="server" Title="Otobüsler" AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                 <ext:Button runat="server" ID="btnAddNew" Text="Yeni Araç Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">
                 </ext:Button>
                    <ext:Button ID="btnGetAccounts" runat="server" Icon="Find" OnDirectClick="btnGetAccounts_DirectClick" Text="Listele">
                        <DirectEvents>
                            <Click Timeout="2000000">
                                <EventMask Msg="Kayıtlar Getiriliyor. Lütfen bekleyiniz..." ShowMask="true"></EventMask>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Label ID="Label2" runat="server" FieldLabel="Kayıt Sayısı : "></ext:Label>
                </Items>
            </ext:Toolbar>
        </TopBar>

        <Store>
            <ext:Store runat="server" ItemID="ID">
                <Model>
                    <ext:Model runat="server" IDProperty="busId">
                        <Fields>
                            <ext:ModelField Name="busId"></ext:ModelField>
                            <ext:ModelField  Name="plate"></ext:ModelField>
                             <ext:ModelField Name="busModel"></ext:ModelField>
                            <ext:ModelField Name="maxBusPessenger"></ext:ModelField>
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
               <%-- <ext:Column runat="server" DataIndex="busId" Flex="2" Text="" ></ext:Column>--%>
                <ext:Column  runat="server" DataIndex="plate" Flex="2" Text="Plaka" ></ext:Column>
                <ext:Column runat="server" DataIndex="busModel" Flex="2" Text="Otobüs Modeli"></ext:Column>
                <ext:Column runat="server" DataIndex="maxBusPessenger" Flex="2" Text="Maksimum Yolcu Sayısı"></ext:Column>
                <ext:Column runat="server" DataIndex="state" Flex="2" Text="Durum"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="createdAt" Flex="2" Text="Tarih"></ext:DateColumn>
                    <ext:CommandColumn runat="server" Width="300">
                    <Commands>
                            <ext:GridCommand CommandName="cmdDel" Icon="Delete" Text="Sil">
                        </ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="cmdCommand">
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="plate" Value="record.data.plate"></ext:Parameter>
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
            CloseAction = "Destroy"          
            Closable="true"
            BodyPadding="5"
            Layout="FormLayout"
          Visible="false">           
            <Items>
                <ext:TextField ID="txtPlate" runat="server" FieldLabel="Plaka" AllowBlank="false"/>
                <ext:TextField  ID="txtModel" runat="server" FieldLabel="Otobüs Model" AllowBlank="false" />
                <ext:TextField  ID="txtMaxPassenger" runat="server" FieldLabel="Maksimum Yolcu Sayısı" AllowBlank="false">
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
                <ext:Hidden ID="hdnBusDelete" runat="server"></ext:Hidden>
                <ext:Label runat="server" ID="lblDeleteConfim" HTML="silmek istediğinizden <b>emin misiniz?</b>"></ext:Label>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDeleteConfirmSave" OnDirectClick="btnDeleteConfirmSave_DirectClick" Text="Sil" Icon="DatabaseDelete"></ext:Button>
                <ext:Button runat="server" ID="btnDeleteConfirmCancel" OnDirectClick="btnDeleteConfirmCancel_DirectClick" Text="Vazgeç" Icon="Cancel"></ext:Button>
            </Buttons>
        </ext:Window>       

    </div>
    </form>
</body>
</html>
