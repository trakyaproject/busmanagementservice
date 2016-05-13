<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Client_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title></title>
    <script type="text/javascript">
        var addTab = function (tabPanel, record) {
            var text = record.data.text,
                tab = tabPanel.getComponent(text);

            if (!tab) {
                tab = tabPanel.add({ 
                    id: text,
                    title: text,
                    closable: true,
                    loader: {
                        url: record.data.url,
                        renderer: "frame",
                        loadMask: {
                            showMask: true,
                            msg: "Yükleniyor " + text + "..."
                        }
                    }
                });
            }
            tabPanel.setActiveTab(tab);
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Default"  ID="ResourceManager1"/>
    <form id="form1" runat="server">
    <ext:Viewport ID="Viewport1" runat="server" StyleSpec="background-color: transparent;" Layout="BorderLayout">
        <Items>
            <ext:Panel
                runat="server"
                ID="pnlTop"
                Region="North"
                BodyStyle="background-color: #cbdbef;"
               >
                <BottomBar>
                   <ext:StatusBar 
                        ID="StatusBar2" 
                        runat="server"
                        Padding="3"
                        
                        StatusAlign="Left"
                        Height="30"
                    >
                    <Items>
                        <ext:Button ID="btnLogOut" runat="server" Text="Güvenli Çıkış" Flat="true" Icon="Delete" Width="100" OnDirectClick="btnLogOut_DirectClick" Height="25"></ext:Button>
                    </Items>
                </ext:StatusBar>
                </BottomBar>
            </ext:Panel>

            <ext:Panel 
                    runat="server"
                    Region="West" 
                    Width="270" 
                
                    ID="pnlSettings"
                    BodyStyle="background-color: #fff;"
                    Split="true"
                    MinWidth="150" 
                    MaxWidth="200" 
                    MarginsSummary="31 0 5 5" 
                    CMarginsSummary="31 5 5 5"
                    Layout="VBoxLayout"
               
                    
               >
               <Items>
               <ext:Image ID="Image1" runat="server"  Margin="30" ImageUrl="~/image/bus-front_318-33490.png"   Width="80" Height="70"></ext:Image>
               <ext:TreePanel 
                ID="TreePanel1" 
                runat="server" 
                Title="Menü"
                Height="600"
                Width="200"
                UseArrows="true"
                AutoScroll="true"
                Animate="true"            
                HideHeaders="true"
                RootVisible="false"
                Border="false"
                >
                    <Fields>
                        <ext:ModelField Name="url" />
                    </Fields>
                    <Root>
                        <ext:Node>
                            <Children>
                                <ext:Node Expanded="true" Icon="TableCell" Text="Tanımlar"  NodeID="nodeMenu">
                                    <Children>
                                         
                                        <ext:Node Leaf="true" Text="Otobüsler" NodeID="nodeBus" Icon="Car">
                                            <CustomAttributes>
                                                <ext:ConfigItem Mode="Value" Name="url" Value="Bus.aspx">
                                                </ext:ConfigItem>
                                            </CustomAttributes>
                                        </ext:Node>
                                        <ext:Node Leaf="true" Text="Şoförler" NodeID="nodeDriver" Icon="UserGray">
                                            <CustomAttributes>
                                                <ext:ConfigItem Mode="Value" Name="url" Value="Driver.aspx">
                                                </ext:ConfigItem>
                                            </CustomAttributes>
                                        </ext:Node>

                                         <ext:Node Leaf="true" Text="Hat-Durak" NodeID="nodeStation" Icon="TabGo">
                                            <CustomAttributes>
                                                <ext:ConfigItem Mode="Value" Name="url" Value="Station.aspx">
                                                </ext:ConfigItem>
                                            </CustomAttributes>
                                        </ext:Node>
                                    </Children>
                                </ext:Node>
                            </Children>
                            <Children>
                                <ext:Node Expanded="true"  Text="Raporlar" NodeID="nodeMenu1" Icon="PageWhiteText">
                                    <Children>
                                         
                                        <ext:Node Leaf="true" Text="Vardiya" NodeID="nodeCeza" Icon="Time">
                                            <CustomAttributes>
                                                <ext:ConfigItem Mode="Value" Name="url" Value="ShiftTime.aspx">
                                                </ext:ConfigItem>
                                            </CustomAttributes>
                                        </ext:Node>
                                        
                                    </Children>
                                </ext:Node>
                            </Children>
                        </ext:Node>

                    </Root>
                </ext:TreePanel>
                </Items>   
            </ext:Panel>

            <ext:TabPanel 
                ID="pnlTab"
                Region="Center"
                runat="server" 
                Border="false" 
                BodyStyle="background-color: #4D778B; border: 1px solid #AABBCC; border-top: none;"
                MarginsSummary="0 0 0 0">
            </ext:TabPanel> 
            <ext:Panel
                runat="server"
                ID="btnBottomPanel"
                Region="South"
                
                >
                <BottomBar>
                   <ext:StatusBar 
                    ID="StatusBar1" 
                    runat="server"
                    
                    >
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:Label ID="lblUserName" runat="server"/>
                                <ext:ToolbarSpacer ID="ToolbarSpacer1"  runat="server" Width="20"></ext:ToolbarSpacer>
                                <ext:Label ID="lblFirmName" runat="server" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server"></ext:ToolbarSpacer>
                                <ext:Label ID="lblBranch" runat="server" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer3"  Width="20" runat="server"></ext:ToolbarSpacer>
                                 <ext:Label ID="Label1" runat="server" Text="Saygılar" />
                            </Items>
                        </ext:Panel>
                        
                    </Items>
                </ext:StatusBar>
                </BottomBar>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>