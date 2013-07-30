<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" Title="EIMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
        <asp:Label runat="server" ID="WelcomeBackMessage">
</asp:Label>
    </asp:Panel>
    
    <asp:Panel runat="Server" ID="AnonymousMessagePanel">
        <div class="Home-Image">
        <asp:Image ID="Image1" runat="server" AlternateText="EIMS-Image" ImageUrl="~/img/for-students.jpg" />
        <div class="Image-Footer"><p style="font-size:30px;">Education made organised.</p></div>
            </div>
        <div class="Home-Login">
        <asp:Login ID="Login1" runat="server" BackColor="White">
        </asp:Login>
            </div>
    </asp:Panel>
    <div style="float:left">
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse eget leo condimentum, suscipit sapien a, cursus enim. Etiam dictum, orci sed aliquet auctor, nibh nunc elementum lectus, eget mollis urna eros pharetra ipsum. Ut nec rutrum sem. Nam vitae sem magna. Quisque eleifend pharetra massa sit amet auctor. Sed leo quam, congue et congue at, fringilla id nisl. Nam vitae nibh suscipit, lobortis elit in, sagittis nunc. Pellentesque hendrerit, lectus ac condimentum convallis, nisl diam ullamcorper risus, non sagittis quam tortor non ante. Ut fringilla non diam at vulputate. Nunc arcu est, tincidunt et sollicitudin nec, luctus non est. Sed posuere nibh quis mollis placerat. Sed quis ultrices leo. Pellentesque ut orci nisl. Suspendisse potenti. Vivamus semper justo et nulla accumsan, nec tincidunt mauris auctor. Aenean at libero quis odio commodo rhoncus vel ut turpis. Nam sit amet tortor nec odio luctus scelerisque. Suspendisse mollis sit amet orci sit amet malesuada. Praesent accumsan elementum sapien, sit amet aliquet massa tempus et. Maecenas venenatis elementum mi non suscipit. Praesent sollicitudin rhoncus arcu quis posuere. Phasellus justo tellus, pellentesque eu nisl sodales, tincidunt ultrices lectus. Curabitur ac vehicula eros. Donec et gravida odio. Donec consectetur, ante porta consequat ultricies, velit mauris suscipit felis, et porttitor elit ante ac sapien. Duis vestibulum ultricies risus non semper. 
In consequat mauris in nibh luctus, nec dignissim ipsum rhoncus. Curabitur sed ipsum dui. Duis dignissim turpis a orci hendrerit, dignissim hendrerit quam placerat. Etiam interdum, libero eget ultrices volutpat, nisl dolor dictum lorem, et tincidunt ligula ante eu mi. Curabitur congue aliquam nibh, in sodales ligula. Pellentesque ut justo eget dui aliquet adipiscing ultrices quis turpis. Nulla in dapibus nibh. Suspendisse interdum luctus ligula, a faucibus massa tristique nec. Sed ut nibh eget tortor ornare sollicitudin. Vestibulum interdum turpis eu iaculis vestibulum. Donec rhoncus mauris commodo erat accumsan rutrum. Maecenas aliquet lacinia ornare. Pellentesque semper dapibus semper. Nulla facilisi. Duis imperdiet sed nisl eget imperdiet. 
Etiam dui tellus, bibendum vel leo ac, molestie porta mauris. Cras vel facilisis turpis, ac rhoncus nulla. Mauris sodales metus urna, eget sollicitudin augue iaculis ac. Cras rutrum auctor lacus sit amet viverra. Proin sit amet orci urna. Aenean risus dolor, gravida non urna nec, blandit dignissim orci. Vestibulum pharetra tellus sit amet velit congue, interdum rutrum lacus laoreet. Integer sagittis, arcu in pretium gravida, libero libero sagittis lacus, a mollis mi mi sit amet risus. Pellentesque ut urna hendrerit leo convallis hendrerit. Fusce adipiscing erat urna, pretium dignissim mi consectetur suscipit. Integer accumsan luctus orci non accumsan. Sed ornare auctor mauris, quis mollis sem sagittis eget. Nunc feugiat, est eu mattis commodo, sem erat vehicula tellus, euismod ornare libero neque rutrum lectus. Morbi mattis, lacus nec imperdiet malesuada, sem diam facilisis lorem, vel fringilla leo est a massa. Mauris ac augue quis orci condimentum aliquet bibendum sed quam. 
</p>
        </div>
    <p>&nbsp;</p>
</asp:Content>