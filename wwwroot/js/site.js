// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.// Write your JavaScript code.

$(document).ready(function () {
    $("#MyLink1").click(function () {
        var id = parseInt($("#NumMat").val());
        this.href = this.href + '/' + id;
    });
});

$(document).ready(function () {
    $("button").click(function () {
        $("p").toggle();
    });
});

$(function () {
    $('#MyLink2').click(function () {
        var value = $('#NumMat').val();
        $(this).attr('href', function () {
            return this.href += '?param=' + encodeURIComponent(value);
        });
    });
});

$(document).ready(function () {
    //jQuery on button click Call

    $("#btn").click(function () {

        $.ajax({ url: 'https://richnjembcptedatabase.blob.core.windows.net/nrtct/Personnel1.xml', method: 'GET', dataType: 'xml' }).done(function (xml) {
            var xmlDoc = $.parseXML(xml);
            var author = $(xmlDoc).find('PERSO').find('Matricule');
            $('#content').append('<span>' + author.text() + '</span>');
            alert(author.text())
        });

                  
    });
});
