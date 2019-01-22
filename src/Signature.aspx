﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signature.aspx.cs" Inherits="GroupDocs.Total.WebForms.Signature" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <title>Signature for Java Dropwizard</title>
    <link type="text/css" rel="stylesheet" href="/resources/common/css/all.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/v4-shims.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/swiper.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/jquery-ui.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/circle-progress.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer-dark.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPaint.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPaint.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/signature.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/signature.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/stampGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/opticalCodeGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/textGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPicker.css" />
    <script type="text/javascript" src="/resources/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/swiper.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="resources/common/js/es6-promise.auto.js"></script>
    <script type="text/javascript" src="/resources/viewer/js/viewer.js"></script>
    <script type="text/javascript" src="/resources/signature/js/signature.js"></script>
    <script type="text/javascript" src="/resources/signature/js/rotatable.js"></script>
    <script type="text/javascript" src="/resources/signature/js/bcPaint.js"></script>
    <script type="text/javascript" src="/resources/signature/js/bcPicker.js"></script>
    <script type="text/javascript" src="/resources/signature/js/stampGenerator.js"></script>
    <script type="text/javascript" src="/resources/signature/js/opticalCodeGenerator.js"></script>
    <script type="text/javascript" src="/resources/signature/js/textGenerator.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery.ui.touch-punch.min.js"></script>
</head>
<body>
    <div id="element"></div>
    <script type="text/javascript">       
        $('#element').signature({
            applicationPath: 'http://<%= config.Server.HostAddress%>:<%= config.Server.HttpPort%>/signature',
            defaultDocument: '<%= config.Signature.DefaultDocument%>',
            preloadPageCount: <%= config.Signature.PreloadPageCount%>,
            pageSelector: <%= config.Common.isPageSelector.ToString().ToLowerInvariant()%>,
            download: <%= config.Common.isDownload.ToString().ToLowerInvariant()%>,
            upload: <%= config.Common.isUpload.ToString().ToLowerInvariant()%>,
            print: <%= config.Common.isPrint.ToString().ToLowerInvariant()%>,
            browse: <%= config.Common.isBrowse.ToString().ToLowerInvariant()%>,
            rewrite: <%= config.Common.isRewrite.ToString().ToLowerInvariant()%>,
            textSignature:  <%= config.Signature.isTextSignature.ToString().ToLowerInvariant()%>,
            imageSignature: <%= config.Signature.isImageSignature.ToString().ToLowerInvariant()%>,
            digitalSignature: <%= config.Signature.isDigitalSignature.ToString().ToLowerInvariant()%>,
            qrCodeSignature: <%= config.Signature.isQrCodeSignature.ToString().ToLowerInvariant()%>,
            barCodeSignature: <%= config.Signature.isBarCodeSignature.ToString().ToLowerInvariant()%>,
            stampSignature: <%= config.Signature.isStampSignature.ToString().ToLowerInvariant()%>            
        });
    </script>
</body>
</html>

