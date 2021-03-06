// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('submit', '#Registrar', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Registrar button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Usuario registrado con exito.');
            window.location.href = "/Usuario";
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        },
        complete: function () {
            $('#Registrar button[type=submit]').prop('disabled', false);
        }
    })
})

$(document).on('submit', '#Login', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Login button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Bienvenido ' + data.nombre);
            window.location.href = "/Home";
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        },
        complete: function () {
            $('#Login button[type=submit]').prop('disabled', false);
        }
    })
})

$(document).on('submit', '#Actividad', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Actividad button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Actividad Registrada con exito');
            window.location.href = "/Actividad";
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        },
        complete: function () {
            $('#Actividad button[type=submit]').prop('disabled', false);
        }
    })
})

$(document).on('submit', '#ActividadEdit', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#ActividadEdit button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Actividad Editada con exito');
            window.location.href = "/Actividad";
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        },
        complete: function () {
            $('#ActividadEdit button[type=submit]').prop('disabled', false);
        }
    })
})

$(document).ready(function () {
    //Total llamadas
    $.ajax({
        type: "GET",
        url: "/Dashboard/TotalLlamadas",
        success: function (data) {
            $(".Total_llamadas").text(data.total);
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        }
    })
    //Total llamadas resueltas
    $.ajax({
        type: "GET",
        url: "/Dashboard/TotalLlamadasRes",
        success: function (data) {
            $(".Total_llamadasRes").text(data.total);
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        }
    })
    //Total llamadas no resueltas
    $.ajax({
        type: "GET",
        url: "/Dashboard/TotalLlamadasNoRes",
        success: function (data) {
            $(".Total_llamadasNoRes").text(data.total);
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        }
    })
});