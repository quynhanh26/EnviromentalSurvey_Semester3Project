
$(document).ready(function () {

    function convertDate(stringDate) {
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(stringDate)
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
    }
    $("#next").click(function () {
        var message = $('#textAfq').val();
        $("#faq").val(message)
        $("#AnswerModal").modal("show");
        $("#addFAQModal").modal("hide");

    });

    $("#cancle").click(function () {
        $("#AnswerModal").modal("toggle");
        $("#addFAQModal").modal("show");
    });
    $("#save").click(function () {
        var faq = $("#faq").val();
        var answer = $("#answer").val();

        $.ajax({
            type: 'GET',
            url: '/admin/faq/create',
            data: {
                faq: faq,
                answer: answer
            },
            contentType: '/application/json; charset=utf-8',
            dataType: 'json',
            success: function (listFaq) {
                var result = '';
                console.log(listFaq);
                for (var i = 0; i < listFaq.length; i++) {
                    result += '<tr>';
                    result += '<td hidden>' + listFaq[i].id + '</td>';
                    result += '<td>' + listFaq[i].faq1 + '</td>';
                    result += '<td>' + listFaq[i].anSwer + '</td>';
                    result += '<td><button type="button" class="btn btn-gradient-warning btnUpdateFAQ"><i class="mdi mdi-grease-pencil"></i></button>';
                    result += '<button type="button" class="btn btn-gradient-danger btnDelFAQ"><i class="mdi mdi-delete-forever"></i></button></td>';
                    result += '</tr>';
                }
                $('#tbodyFAQ').html(result);
                $("#AnswerModal").modal("toggle");
                $('#textAfq').val("");

                alert("Success");
            }
        });
    });


    $("#tableFAQ").on('click', '.btnUpdateFAQ', function () {

        var currentRow = $(this).closest("tr");

        var idFaq = currentRow.find("td:eq(0)").text();
        var faq = currentRow.find("td:eq(1)").text();
        var answer = currentRow.find("td:eq(2)").text();
        $("#updateFAQModal").modal("show");
        $("#afqUpdate").val(faq);
        $("#idUpdate").val(idFaq);
        $("#answerUpdate").val(answer);

    });
    $("#nextUpdate").click(function () {
        $("#AnswerUpdate").modal("show");
        $("#updateFAQModal").modal("hide");
    });
    $("#cancleUpdate").click(function () {
        $("#AnswerUpdate").modal("toggle");
        $("#updateFAQModal").modal("show");
    });
    $("#update").click(function () {
        var id = $("#idUpdate").val();
        var faq = $("#afqUpdate").val();
        var answer = $("#answerUpdate").val();

        $.ajax({
            type: 'GET',
            url: '/admin/faq/update',
            data: {
                idFaq: id,
                faq: faq,
                answer: answer
            },
            contentType: '/application/json; charset=utf-8',
            dataType: 'json',
            success: function (listFaq) {
                var result = '';
                console.log(listFaq);
                for (var i = 0; i < listFaq.length; i++) {
                    result += '<tr>';
                    result += '<td hidden>' + listFaq[i].id + '</td>';
                    result += '<td>' + listFaq[i].faq1 + '</td>';
                    result += '<td>' + listFaq[i].anSwer + '</td>';
                    result += '<td><button type="button" class="btn btn-gradient-warning btnUpdateFAQ"><i class="mdi mdi-grease-pencil"></i></button>';
                    result += '<button  class="btn btn-gradient-danger btnDelFAQ" ><i class="mdi mdi-delete-forever"></i></button></td>';
                    result += '</tr>';
                }
                $('#tbodyFAQ').html(result);
                $("#AnswerUpdate").modal('hide');

                alert("Success");
            }
        });
    });
    $("#tableFAQ").on('click', '.btnDelFAQ', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idFaq = currentRow.find("td:eq(0)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/faq/del',
                data: {
                    idFaq: idFaq
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (listFaq) {
                    var result = '';
                    console.log(listFaq);
                    for (var i = 0; i < listFaq.length; i++) {
                        result += '<tr>';
                        result += '<td hidden>' + listFaq[i].id + '</td>';
                        result += '<td>' + listFaq[i].faq1 + '</td>';
                        result += '<td>' + listFaq[i].anSwer + '</td>';
                        result += '<td><button type="button" class="btn btn-gradient-warning btnUpdateFAQ"><i class="mdi mdi-grease-pencil"></i></button>';
                        result += '<button type="button" class="btn btn-gradient-danger btnDelFAQ"><i class="mdi mdi-delete-forever"></i></button></td>';
                        result += '</tr>';
                    }
                    $('#tbodyFAQ').html(result);
                    alert("Success");
                }
            });
        }
    });
    $("#tableAcc").on('click', '.btnDelAcc', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idAcc = currentRow.find("td:eq(0)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/account/del',
                data: {
                    idAcc: idAcc
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (listAcc) {
                    var result = '';

                    for (var i = 0; i < listAcc.length; i++) {
                        result += '<tr>';
                        result += '<td hidden>' + listAcc[i].id + '</td>';
                        result += '<td><img src="/img/avatar/' + listAcc[i].img + '" class="mr-2" alt="image">' + listAcc[i].userName + '</td>';
                        result += '<td>' + listAcc[i].idPeople + '</td>';
                        result += '<td>' + convertDate(listAcc[i].date) + '</td>';
                        result += '<td>' + listAcc[i].role + '</td>';
                        if (listAcc[i].status) {
                            result += '<td><label class="badge badge-gradient-success" > ENABLE</label></td>';
                        } else {
                            result += '<td><label class="badge badge-gradient-danger" > DISNABLE</label></td>';
                        }
                        result += '<td><button class="btn btn-gradient-danger btnDelAcc"><i class="mdi mdi-account-remove"></i></button></td>';
                        result += '</tr>';
                    }
                    $('#tbodyAcc').html(result);
                    alert("Success");
                }
            });
        }
    });
});
