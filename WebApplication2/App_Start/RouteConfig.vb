Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim sConfigurationManager As FriendlyUrlSettings = New FriendlyUrlSettings() With {
            .AutoRedirectMode = RedirectMode.Permanent
        }
        routes.EnableFriendlyUrls(sConfigurationManager)
    End Sub
End Module
