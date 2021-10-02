$(document).ready(function () {
    function convertDate1(stringDate) {
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(stringDate)
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
    }

    $("#tableQuestion").on('click', '.delQuestion', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idQuestion = currentRow.find("td:eq(0)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/question/delQuestion',
                data: {
                    idQuestion: idQuestion
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (listQuestion) {
                    var result = '';
                    console.log(listQuestion)
                    for (var i = 0; i < listQuestion.length; i++) {
                        result += '<tr>';
                        result += '<td>' + listQuestion[i].id + '</td>';
                        result += '<td>' + listQuestion[i].question1 + '</td>';
                        result += '<td>' + convertDate1(listQuestion[i].updated) + '</td>';
                        if (listQuestion[i].status) {
                            result += '<td><label class="badge badge-success">enable</label></td>';
                        }
                        else {
                            result += '<td><label class="badge badge-danger">disnable</label></td>';
                        }
                        result += '<td><button class="btn btn-gradient-danger delQuestion" type="button"><i class="mdi mdi-delete"></i></button>';
                        result += '<button class="btn btn-gradient-warning"><a href = "/admin/question/detailQues?idQues=' + listQuestion[i].id + '" >';
                        result += '<i class="mdi mdi-format-list-bulleted menu-icon" ></i ></a ></button></td> ';
                        result += '</tr>';
                    }
                    $('#bodyQuestion').html(result);
                    alert("Success");
                }
            });
        }
    });
    $("#addQuestion").submit(function (e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            type: "POST",
            url: "/admin/question/create",
            data: form.serialize(),
            success: function (listQuestion) {
                var result = '';
                console.log(listQuestion)
                for (var i = 0; i < listQuestion.length; i++) {
                    result += '<tr>';
                    result += '<td>' + listQuestion[i].id + '</td>';
                    result += '<td>' + listQuestion[i].question1 + '</td>';
                    result += '<td>' + convertDate1(listQuestion[i].updated) + '</td>';
                    if (listQuestion[i].status) {
                        result += '<td><label class="badge badge-success">enable</label></td>';
                    }
                    else {
                        result += '<td><label class="badge badge-danger">disnable</label></td>';
                    }
                    result += '<td><button class="btn btn-gradient-danger delQuestion" type="button"><i class="mdi mdi-delete"></i></button>';
                    result += '<button class="btn btn-gradient-warning"><a href = "/admin/question/detailQues?idQues=' + listQuestion[i].id + '" >';
                    result += '<i class="mdi mdi-format-list-bulleted menu-icon" ></i ></a ></button></td> ';
                    result += '</tr>';
                }
                $('#bodyQuestion').html(result);
                alert("Success");
            }
        });
    });
    $("#tableAnswer").on('click', '.btnDelAnswer', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idQues = currentRow.find("td:eq(0)").text();
            var idAnswer = currentRow.find("td:eq(1)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/answer/del',
                data: {
                    idAnswer: idAnswer,
                    idQues: idQues
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (listAnswer) {
                    var result = '';
                    console.log(listAnswer);
                    for (var i = 0; i < listAnswer.length; i++) {
                        result += '<tr>';
                        result += '<td hidden>' + listAnswer[i].idQuestion + '</td>';
                        result += '<td>' + listAnswer[i].id + '</td>';
                        result += '<td>' + listAnswer[i].answer1 + '</td>';
                        result += '<td>' + convertDate1(listAnswer[i].updated) + '</td>';
                        if (listAnswer[i].status) {
                            result += '<td><label class="badge badge-success">True</label></td >';
                        }
                        else {
                            result += '<td><label class="badge badge-danger">False</label></td >';
                        }
                        result += '<td><button class="btn btn-gradient-warning btnUpdateAnswer"><i class="mdi mdi-grease-pencil"></i></button>';
                        result += '<button class="btn btn-gradient-danger btnDelAnswer" > <i class="mdi mdi-delete-forever"></i></button > ';
                        result += '</tr>';
                    }
                    $('#bodyAnswer').html(result);
                    alert("Success");
                }
            });
        }
    });
    $("#addAnswer").submit(function (e) {

        e.preventDefault();
        var form = $(this);
        $.ajax({
            type: "POST",
            url: "/admin/answer/add",
            data: form.serialize(),
            success: function (listAnswer) {
                var result = '';
                for (var i = 0; i < listAnswer.length; i++) {
                    result += '<tr>';
                    result += '<td hidden>' + listAnswer[i].idQuestion + '</td>';
                    result += '<td>' + listAnswer[i].id + '</td>';
                    result += '<td>' + listAnswer[i].answer1 + '</td>';
                    result += '<td>' + convertDate1(listAnswer[i].updated) + '</td>';
                    if (listAnswer[i].status) {
                        result += '<td><label class="badge badge-success">True</label></td >';
                    }
                    else {
                        result += '<td><label class="badge badge-danger">False</label></td >';
                    }
                    result += '<td><button class="btn btn-gradient-warning btnUpdateAnswer"><i class="mdi mdi-grease-pencil"></i></button>';
                    result += '<button class="btn btn-gradient-danger btnDelAnswer" > <i class="mdi mdi-delete-forever"></i></button > ';
                    result += '</tr>';
                }
                $('#bodyAnswer').html(result);
                alert("Success");
            }
        });

    });
    $("#tableAnswer").on('click', '.btnUpdateAnswer', function () {
        var currentRow = $(this).closest("tr");
        var idQuestion = currentRow.find("td:eq(0)").text();
        var idAnswer = currentRow.find("td:eq(1)").text();
        var answer = currentRow.find("td:eq(2)").text();
        var status = currentRow.find("td:eq(4)").text();
        $("#updateAnswerModal").modal("show");
        $("#idAnswer").val(idAnswer);
        $("#idQuestion").val(idQuestion);
        $("#Answer").val(answer);
        if (status === "True") {
            $("#status").prop('checked', true);
        } else {
            $("#status").prop('checked', false);
        }
    });
    $("#updateAnswer").submit(function (e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            type: "POST",
            url: "/admin/answer/update",
            data: form.serialize(),
            success: function (listAnswer) {
                var result = '';
                for (var i = 0; i < listAnswer.length; i++) {
                    result += '<tr>';
                    result += '<td hidden>' + listAnswer[i].idQuestion + '</td>';
                    result += '<td>' + listAnswer[i].id + '</td>';
                    result += '<td>' + listAnswer[i].answer1 + '</td>';
                    result += '<td>' + convertDate1(listAnswer[i].updated) + '</td>';
                    if (listAnswer[i].status) {
                        result += '<td><label class="badge badge-success">True</label></td >';
                    }
                    else {
                        result += '<td><label class="badge badge-danger">False</label></td >';
                    }
                    result += '<td><button class="btn btn-gradient-warning btnUpdateAnswer"><i class="mdi mdi-grease-pencil"></i></button>';
                    result += '<button class="btn btn-gradient-danger btnDelAnswer" > <i class="mdi mdi-delete-forever"></i></button > ';
                    result += '</tr>';
                }
                $('#bodyAnswer').html(result);
                alert("Success");
            }
        });

    });
    $("#updateQuestionModal").on('show.bs.modal', function () {
        var question = $("#questionOld").val();
      
        $("#question").val(question);
        if ($('#statusQuesOld').is(':checked')) {
            $("#statusQues").prop('checked', true);
        } else {
            $("#statusQues").prop('checked', false);
        }
    });
 
});