<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Driver.aspx.cs" Inherits="Client_Driver" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    <form id="form1" runat="server">
    <div>
   
        <ext:Hidden runat="server" ID="hdnDriverType"></ext:Hidden>
        <ext:GridPanel ID="grdDriver" runat="server"  AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                 <ext:Button runat="server" ID="btnAddNew" Text="Yeni Şoför Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">
                 </ext:Button>
                    <ext:Button ID="btnGet" runat="server" Icon="Find" OnDirectClick="btnGet_DirectClick" Text="Listele">
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
                    <ext:Model  runat="server" IDProperty="driverId">
                        <Fields>
                            <ext:ModelField Name="driverId"></ext:ModelField>
                            <ext:ModelField Name="nameSurname"></ext:ModelField>
                            <ext:ModelField Name="tc"></ext:ModelField>
                            <ext:ModelField Name="birthday"></ext:ModelField>
                            <ext:ModelField Name="bloodGroup"></ext:ModelField>
                            <ext:ModelField Name="phone"></ext:ModelField>
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
                <ext:RowNumbererColumn runat="server" Text="Sıra No" Width="80"></ext:RowNumbererColumn>
               <%-- <ext:TemplateColumn runat="server" Text ="" Flex="15" DataIndex="url" TemplateString='<img style="width:60px;height:45px;" src="" />'/>--%>
                <%--<ext:Column  runat="server" DataIndex="driverId" Flex="2" Text="Adı" ></ext:Column>--%>
                <ext:Column runat="server" DataIndex="driverId" Flex="2" Visible="false" Text="" ></ext:Column>
                <ext:Column  runat="server" DataIndex="nameSurname" Flex="2" Text="Adı Soyadı"></ext:Column>
                <ext:Column runat="server" DataIndex="tc" Flex="2" Text="T.C. Kimlik No"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="birthday" Flex="2" Text="Doğum Tarihi"></ext:DateColumn>
                <ext:Column runat="server" DataIndex="bloodGroup" Flex="2" Text="Kan Grubu"></ext:Column>
                <ext:Column  runat="server" DataIndex="phone" Flex="2" Text="Telefon"></ext:Column>
                <ext:Column  runat="server" DataIndex="address" Flex="2" Text="Adres"></ext:Column>
                <ext:Column  runat="server" DataIndex="state" Flex="2" Text="Durum"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="createdAt" Flex="2" Text="Tarih"></ext:DateColumn>
                <ext:CommandColumn runat="server" Width="300">
                    <Commands>
                         <ext:GridCommand CommandName="cmdUpdate" Icon="ApplicationEdit" Text="Güncelle"> </ext:GridCommand>
                        <ext:GridCommand CommandName="cmdDel" Icon="Delete" Text="Sil"></ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="cmdCommand">
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="tc" Value="record.data.tc"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="driverId" Value="record.data.driverId"></ext:Parameter>
                            </ExtraParams>
                            <EventMask Msg="Bilgiler getiriliyor...Lütfen Bekleyiniz.." ShowMask="true"></EventMask>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        </ext:GridPanel>
       <ext:Window ID="WindowDriver" 
            runat="server" 
            Width="600"
            Modal="true"
            CloseAction = "Destroy"
            Hidden="true"          
            Closable="true"
            BodyPadding="5"
            Layout="FormLayout"
          >           
            <Items>
                <ext:TextField ID="txtdriverId" runat="server"  FieldLabel="Sıra No" ReadOnly="true" Visible="true" AllowBlank="false"/>
                 <ext:TextField  ID="txttc" runat="server" FieldLabel="T.C. Kimlik No" AllowBlank="false" />
                <ext:TextField ID="txtnameSurname" runat="server" FieldLabel="Adı Soyadı" AllowBlank="false"/>               
                <ext:DateField  ID="txtbirthday" runat="server" FieldLabel="Doğum Tarihi" AllowBlank="false" />
                <ext:TextField  ID="txtbloodGroup" runat="server" FieldLabel="Kan Grubu" AllowBlank="false" />
                <ext:TextField  ID="txtphone" runat="server" FieldLabel="Telefon" AllowBlank="false" />
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
                <ext:Hidden ID="hdnDriverDelete" runat="server"></ext:Hidden>
                <ext:Label runat="server" ID="lblDeleteConfim" HTML="silmek istediğinizden <b>emin misiniz?</b>"></ext:Label>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDeleteConfirmSave" OnDirectClick="btnDelete_DirectClick" Text="Sil" Icon="DatabaseDelete"></ext:Button>
                <ext:Button runat="server" ID="btnDeleteConfirmCancel" OnDirectClick="btnCancel_DirectClick" Text="Vazgeç" Icon="Cancel"></ext:Button>
            </Buttons>
        </ext:Window>       



    </div>
    </form>
</body>
</html>


