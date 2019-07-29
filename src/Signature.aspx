﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signature.aspx.cs" Inherits="GroupDocs.Total.WebForms.Signature" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <title>GroupDocs.Signature</title>
    <link type="text/css" rel="stylesheet" href="/resources/common/css/all.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/v4-shims.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/swiper.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/jquery-ui.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/circle-progress.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/font-awesome.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer-dark.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPaint.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPaint.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/signature.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/signature.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/stampGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/opticalCodeGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/opticalCodeGenerator.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/textGenerator.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPicker.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/bcPicker.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/signature/css/stampGenerator.mobile.css" />
    <script type="text/javascript" src="/resources/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/swiper.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/es6-promise.auto.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="/resources/viewer/js/viewer.js"></script>
    <script type="text/javascript" src="/resources/signature/js/fontsObject.js"></script>
    <script type="text/javascript" src="/resources/signature/js/jquery.ba-throttle-debounce.js"></script>
    <script type="text/javascript" src="/resources/signature/js/signature.js"></script>
    <script type="text/javascript" src="/resources/signature/js/rotatable.js"></script>
    <script type="text/javascript" src="/resources/signature/js/bcPaint.js"></script>
    <script type="text/javascript" src="/resources/signature/js/bcPicker.js"></script>
    <script type="text/javascript" src="/resources/signature/js/stampGenerator.js"></script>
    <script type="text/javascript" src="/resources/signature/js/opticalCodeGenerator.js"></script>
    <script type="text/javascript" src="/resources/signature/js/textGenerator.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <div id="element"></div>
    <script type="text/javascript">       
        $('#element').signature({
            applicationPath: 'http://<%= config.GetServerConfiguration().HostAddress%>:<%= config.GetServerConfiguration().HttpPort%>/signature',
            defaultDocument: '<%= config.GetSignatureConfiguration().DefaultDocument%>',
            preloadPageCount: <%= config.GetSignatureConfiguration().PreloadPageCount%>,
            pageSelector: <%= config.GetCommonConfiguration().pageSelector.ToString().ToLowerInvariant()%>,
            download: <%= config.GetCommonConfiguration().download.ToString().ToLowerInvariant()%>,
            upload: <%= config.GetCommonConfiguration().upload.ToString().ToLowerInvariant()%>,
            print: <%= config.GetCommonConfiguration().print.ToString().ToLowerInvariant()%>,
            browse: <%= config.GetCommonConfiguration().browse.ToString().ToLowerInvariant()%>,
            rewrite: <%= config.GetCommonConfiguration().rewrite.ToString().ToLowerInvariant()%>,
            textSignature:  <%= config.GetSignatureConfiguration().isTextSignature.ToString().ToLowerInvariant()%>,
            imageSignature: <%= config.GetSignatureConfiguration().isImageSignature.ToString().ToLowerInvariant()%>,
            digitalSignature: <%= config.GetSignatureConfiguration().isDigitalSignature.ToString().ToLowerInvariant()%>,
            qrCodeSignature: <%= config.GetSignatureConfiguration().isQrCodeSignature.ToString().ToLowerInvariant()%>,
            barCodeSignature: <%= config.GetSignatureConfiguration().isBarCodeSignature.ToString().ToLowerInvariant()%>,
            stampSignature: <%= config.GetSignatureConfiguration().isStampSignature.ToString().ToLowerInvariant()%>,
            handSignature: <%= config.GetSignatureConfiguration().isHandSignature.ToString().ToLowerInvariant()%>,
            downloadOriginal: <%= config.GetSignatureConfiguration().isDownloadOriginal.ToString().ToLowerInvariant()%>,
            downloadSigned: <%= config.GetSignatureConfiguration().isDownloadSigned.ToString().ToLowerInvariant()%>,
            enableRightClick: <%= config.GetCommonConfiguration().enableRightClick.ToString().ToLowerInvariant()%>
        });
    </script>
</body>
</html>

