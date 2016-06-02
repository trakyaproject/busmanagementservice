"<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShiftTime.aspx.cs" Inherits="Client_ShiftTime" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
                     <ext:Hidden runat="server" ID="hdnST"></ext:Hidden>
        <ext:GridPanel ID="grdST" runat="server"  AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                 <ext:Button runat="server" ID="btnAddNew" Text="Ekle" Icon="Add" OnDirectClick="btnAddNew_DirectClick">
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
                        <ext:Model runat="server" ItemID="shiftTimeId"  >
                            <Fields>
                                <ext:ModelField Name="shiftTimeId"/>
                                <ext:ModelField Name="departureTime"/>
                                <ext:ModelField Name="Busplate"  />
                                <ext:ModelField Name="DriverdriverId" />
                                <ext:ModelField Name="LinelineId" />
                                <ext:ModelField Name="stiftStart" />
                                <ext:ModelField Name="shiftEnd" />
                                <ext:ModelField Name="state" />
                                <ext:ModelField Name="createdAt" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel  runat="server">
            <Columns>
                <ext:RowNumbererColumn runat="server" Text="Sıra No" Width="80"></ext:RowNumbererColumn>
                <ext:Column runat="server" DataIndex="shiftTimeId"  Flex="2" Visible="false" Text="" ></ext:Column>
                <ext:Column  runat="server" DataIndex="departureTime"  Flex="2" Text="Kalkış Zamanı"></ext:Column>
                <ext:Column runat="server" DataIndex="Busplate"  Flex="2" Text="Plaka"></ext:Column>
                <ext:Column runat="server" DataIndex="DriverdriverId" Flex="2" Text="Şoför Bilgileri"></ext:Column>
                <ext:Column runat="server" DataIndex="LinelineId" Flex="2" Text="Hat Bilgileri"></ext:Column>
                <ext:Column  runat="server" DataIndex="stiftStart" Flex="2" Text="Başlangıç Zamanı"></ext:Column>
                 <ext:Column  runat="server" DataIndex="shiftEnd" Flex="2" Text="Bitiş Zamanı"></ext:Column>
                <ext:Column  runat="server" DataIndex="state" Flex="2" Text="Durum"></ext:Column>
                <ext:DateColumn runat="server" DataIndex="createdAt" Flex="2" Text="Tarih"></ext:DateColumn>
             </Columns>
        </ColumnModel>
        </ext:GridPanel>
       <ext:Window ID="WindowST" 
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
                <ext:TextField ID="txtshiftTimeId" runat="server"  FieldLabel="Sıra No" ReadOnly="true" Visible="true" AllowBlank="false"/>
                 <ext:ComboBox runat="server" ID="cmbdepartureTime" FieldLabel="Kalkış Zamanı" padding="10" >
                     <Items>
                         <ext:ListItem  Value="08:00" Text="08:00"></ext:ListItem>
                     </Items>
                 </ext:ComboBox>
                <ext:ComboBox ID="cmbplate" runat="server" FieldLabel="Plaka" ValueField="busId" DisplayField="plate" padding="10" >             
                      <Store>
                        <ext:Store ID="cmbPlateList" runat="server">
                            <Model>
                                <ext:Model runat="server" >
                                    <Fields>
                                        <ext:ModelField Name="busId" />
                                        <ext:ModelField Name="plate" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                  
                <ext:ComboBox ID="cmbDriver" runat="server"  ValueField="driverId" DisplayField="nameSurname" FieldLabel="Adı Soyadı" Padding="10">
                    <Store>
                        <ext:Store ID="cmbDriverList" runat="server">
                            <Model>
                                <ext:Model runat="server" >
                                    <Fields>
                                        <ext:ModelField Name="driverId" />
                                        <ext:ModelField Name="nameSurname" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                
                <ext:ComboBox  ID="cmblineName" runat="server" FieldLabel="Hat Bilgileri" ValueField="lineId" DisplayField="lineName" padding="10" >
                      <Store>
                        <ext:Store ID="cmbLineList" runat="server">
                            <Model>
                                <ext:Model runat="server" >
                                    <Fields>
                                        <ext:ModelField Name="lineId" />
                                        <ext:ModelField Name="lineName" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:DateField  ID="txtstiftStart" runat="server" FieldLabel="Başlangıç Zamanı" padding="10" />
                <ext:DateField  ID="txtshiftEnd" runat="server" FieldLabel="Bitiş Zamanı" padding="10" />
                <ext:Button runat="server" ID="Add" Text="Kaydet"  OnDirectClick="btnKaydet_DirectClick" >
                    <DirectEvents>
                               <Click>
                                   <EventMask ShowMask="true" Msg="Kayıt ediliyor."></EventMask>
                               </Click>
                           </DirectEvents>
                        </ext:Button>
            </Items>            
        </ext:Window>     
          <%--<ext:Window runat="server" ID="wndDeleteConfirm" Title="Silme Onayı" Modal="true" Hidden="true" Width="300"  Height="100" BodyStyle="background-color:white;">
            
              <Items>
                <ext:Hidden ID="hdnDriverDelete" runat="server"></ext:Hidden>
                <ext:Label runat="server" ID="lblDeleteConfim" HTML="silmek istediğinizden <b>emin misiniz?</b>"></ext:Label>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDeleteConfirmSave" OnDirectClick="btnDelete_DirectClick" Text="Sil" Icon="DatabaseDelete"></ext:Button>
                <ext:Button runat="server" ID="btnDeleteConfirmCancel" OnDirectClick="btnCancel_DirectClick" Text="Vazgeç" Icon="Cancel"></ext:Button>
            </Buttons>
        </ext:Window>     --%>  
        </form>
  </body>
</html>