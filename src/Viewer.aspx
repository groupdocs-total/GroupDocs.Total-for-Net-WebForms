﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="GroupDocs.Total.WebForms.Viewer" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Viewer for .NET WebForms</title>
    <link rel="icon" type="image/x-icon" href="favicon.ico" />
    <link rel="stylesheet" type="text/css" href="resources/angular/viewer/dist//assets/css/all.min.css" />
</head>
<body>
    <gd-viewer-angular-root></gd-viewer-angular-root>
    <script type="text/javascript" src="resources/angular/viewer/dist//runtime.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/dist//es2015-polyfills.js" nomodule></script>
    <script type="text/javascript" src="resources/angular/viewer/dist//polyfills.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/dist//styles.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/dist//scripts.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/dist//main.js"></script>
</body>
</html>
