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
        <ext:GridPanel ID="grdDriver" runat="server" Title="Şoförler" AutoScroll="true">
        <TopBar>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:TextField ID="txtDriverFilter" runat="server" FieldLabel="Filtre"></ext:TextField>
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
            <ext:Store ID="Store2" runat="server" ItemID="ID">
                <Model>
                    <ext:Model ID="Model2" runat="server" IDProperty="BusID">
                        <Fields>
                            <ext:ModelField Name="DriverID"></ext:ModelField>
                            <ext:ModelField Name="DriverPicture"></ext:ModelField>
                            <ext:ModelField Name="DriverName"></ext:ModelField>
                            <ext:ModelField Name="DriverSurname"></ext:ModelField>
                            <ext:ModelField Name="DriverTC"></ext:ModelField>
                            <ext:ModelField Name="DriverBirthday"></ext:ModelField>
                            <ext:ModelField Name="DriverKanGrubu"></ext:ModelField>
                            <ext:ModelField Name="DriverPhone"></ext:ModelField>
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel2" runat="server">
            <Columns>
                <ext:RowNumbererColumn ID="RowNumbererColumn2" runat="server" Text="" Width="80"></ext:RowNumbererColumn>
                <ext:TemplateColumn runat="server" Text ="" Flex="15" DataIndex="url" TemplateString='<img style="width:60px;height:45px;" src="" />'/>
                <ext:Column ID="Column1" runat="server" DataIndex="DriverName" Flex="2" Text="Adı" ></ext:Column>
                <ext:Column ID="Column2" runat="server" DataIndex="DriverSurname" Flex="2" Text="Soyadı"></ext:Column>
                <ext:Column ID="Column3" runat="server" DataIndex="DriverTC" Flex="2" Text="T.C. Kimlik No"></ext:Column>
                <ext:Column ID="Column4" runat="server" DataIndex="DriverBirthday" Flex="2" Text="Doğum Tarihi"></ext:Column>
                <ext:Column ID="Column5" runat="server" DataIndex="DriverKanGrubu" Flex="2" Text="Kan Grubu"></ext:Column>
                <ext:Column ID="Column6" runat="server" DataIndex="DriverPhone" Flex="2" Text="Telefon"></ext:Column>
                
                    <ext:CommandColumn ID="CommandColumn2" runat="server" Width="300">
                    <Commands>
                            <ext:GridCommand CommandName="cmdExtract" Icon="ApplicationSideList">
                        </ext:GridCommand>
                    </Commands>
                    <DirectEvents>
                        <Command OnEvent="cmdCommand">
                            <ExtraParams>
                                <ext:Parameter Mode="Raw" Name="command" Value="command"></ext:Parameter>
                                <ext:Parameter Mode="Raw" Name="ID" Value="record.data.BusID"></ext:Parameter>
                            </ExtraParams>
                            <EventMask Msg="Bilgiler getiriliyor...Lütfen Bekleyiniz.." ShowMask="true"></EventMask>
                        </Command>
                    </DirectEvents>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        </ext:GridPanel>
                
        <ext:Window runat="server" Modal="true" Hidden="true" Title="Şoförler" Width="600" Height="350" ID="wndDriver">
            <Items>
                 <ext:GridPanel ID="grdDriver1" runat="server" Title="Şoförler Listesi" AutoScroll="true">
                    <Store>
                        <ext:Store ID="Store1" runat="server" ItemID="ID">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="DriverID"></ext:ModelField>
                                         <ext:ModelField Name="DriverName"></ext:ModelField>
                                        <ext:ModelField Name="DriverSurname"></ext:ModelField>
                                         <ext:ModelField Name="DriverTC"></ext:ModelField>
                                        <ext:ModelField Name="DriverBirthday"></ext:ModelField>
                                         <ext:ModelField Name="DriverKangrubu"></ext:ModelField>
                                        <ext:ModelField Name="DriverPhone"></ext:ModelField>
                                     </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn ID="RowNumbererColumn1" runat="server" Text="" Width="60"></ext:RowNumbererColumn>
                            <ext:Column ID="Column7" runat="server" DataIndex="DriverName" Text="Adı" Width="120"></ext:Column>
                            <ext:Column ID="Column8" runat="server" DataIndex="DriverSurname" Text="Soyadı" Flex="1"></ext:Column>
                             <ext:Column ID="Column9" runat="server" DataIndex="DriverTC" Text="T.C. Kimlik No" Width="120"></ext:Column>
                            <ext:Column ID="Column10" runat="server" DataIndex="DriverBirthday" Text="Doğum Tarihi"></ext:Column>
                            <ext:Column ID="Column11" runat="server" DataIndex="DriverKangrubu" Text="Kangrubu"></ext:Column>
                         <ext:Column ID="Column12" runat="server" DataIndex="DriverPhone" Text="Telefon" Flex="1"></ext:Column>
                            
                        </Columns>
                    </ColumnModel>
                    </ext:GridPanel>
            </Items>
        </ext:Window>
    </div>
    </form>
</body>
</html>


