// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('submit', '#Registrar', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Registro button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            alert('Usuario registrado con exito.');
            window.location.href = "/Login";
        },
        error: function (xhr, status) {
            alert(xhr.responseJSON.message);
        },
        complete: function () {
            $('#Registro button[type=submit]').prop('disabled', false);
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
            console.log(data);
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