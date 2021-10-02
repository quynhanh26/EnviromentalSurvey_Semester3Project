$(document).ready(function () {

    function convertDate(stringDate) {
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(stringDate)
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
    }
    function convertDate2(stringDate) {
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(stringDate)
        return [d.getFullYear(), pad(d.getMonth() + 1), pad(d.getDate())].join('/')
    }
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#blah').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        } else {
            $('#blah').attr('src', "");
        }
    }
    $("#inputGroupFile01").change(function () {

        const file = this.files[0];
        const fileType = file['type'];
        const validImageTypes = ['image/gif', 'image/jpeg', 'image/png'];
        if (validImageTypes.includes(fileType)) {
            readURL(this);
        } else {
            alert("Choose Image!!");
            $("#inputGroupFile01").val('');
        }

    });
    $("#addImg").submit(function (e) {
        if (!$('#inputGroupFile01').val()) {
            alert("Choose Image!!");
            e.preventDefault();
        }
    });
    $('#imgSer div:first').addClass('active');
    $('.tableSeminar').DataTable();
    $('.dataTables_length').addClass('bs-select');
    $("#tablePerson").on('click', '.choose', function () {
        var currentRow = $(this).closest("tr");
        var id = currentRow.find("td:eq(0)").text();
        var name = currentRow.find("td:eq(2)").text();
        $("#PresenterModel").modal("hide");
        $("#idPresenter").val(id);
        $("#namePresenter").val(name);
    });
    $("#tableSeminar").on('click', '.delSeminar', function () {
        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idSeminar = currentRow.find("td:eq(0)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/seminar/del',
                data: {
                    idSeminar: idSeminar
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (listSeminar) {
                    var result = '';
                    console.log(listSeminar);
                    for (var i = 0; i < listSeminar.length; i++) {
                        console.log(listSeminar[i].day);
                        result += '<tr>';
                        result += '<td hidden>' + listSeminar[i].id + '</td>';
                        result += '<td><img src="/img/seminar/' + listSeminar[i].img + '" class="mr-2" alt="image">' + listSeminar[i].name + '</td>';
                        result += '<td>' + listSeminar[i].namePresenters + '</td>';
                        result += '<td>' + convertDate(listSeminar[i].day) + '</td>';
                        if (listSeminar[i].status && convertDate2(listSeminar[i].day) < convertDate2(new Date())) {
                            result += '<td><label class="badge badge-gradient-success">Completed</label></td>';
                        } else if (listSeminar[i].status && convertDate2(listSeminar[i].day) >= convertDate2(new Date())) {
                            result += '<td><label class="badge badge-gradient-warning">Coming soon</label></td>';
                        } else {
                            result += '<td><label class="badge badge-gradient-danger">False</label></td>';
                        }
                        result += '<td><button class="btn btn-gradient-danger delSeminar"><i class="mdi mdi-account-remove"></i></button>';
                        result += '<button class="btn btn-gradient-warning"><a href = "/admin/seminar/detail?idSeminar=' + listSeminar[i].id + '" >';
                        result += '<i class="mdi mdi-format-list-bulleted menu-icon" ></i ></a ></button></td> ';
                    }
                    $('#tbobySeminar').html(result);
                    alert("Success");
                }
            });
        }
    });
    $("#updatePrecenter").on('click', '.update', function () {

        if (confirm('are you sure?')) {
            var currentRow = $(this).closest("tr");
            var idSeminar = currentRow.find("td:eq(0)").text();
            var idPrecenter = currentRow.find("td:eq(1)").text();
            $.ajax({
                type: 'GET',
                url: '/admin/seminar/updatePrecenter',
                data: {
                    idSeminar: idSeminar,
                    idPrecenter
                },
                contentType: '/application/json; charset=utf-8',
                dataType: 'json',
                success: function (precenter) {
                    var result = '';
                    result += '<div id="speaker">';
                    result += '<img src="/img/person/' + precenter.img + '" class="img-fluid" style="width:100%; height:300px">';
                    result += '<div id="details">';
                    result += '<h3>' + precenter.name + '</h3>';
                    result += '<p>Birthday:' + convertDate(precenter.dob) + '</p>';
                    if (precenter.status) {
                        result += '<p>Gender: Male</p>';
                    } else {
                        result += '<p>Gender: Male</p>';
                    }
                    result += '<button class="file-upload-browse btn btn-gradient-primary" type="button" data-toggle="modal" data-target="#UpdatePresenter" > Change</button>';
                    result += '</div> </div>';
                    $('#profilePre').html(result);
                    alert("Success");
                }
            });
        };

    });

    $(".delPre").submit(function (e) {

        if (confirm('are you sure?')) {
            e.preventDefault();
            var form = $(this);
            $.ajax({
                type: "POST",
                url: "/admin/seminar/delPerforment",
                data: form.serialize(),
                success: function (performent) {
                    var result = '';
                    if (performent.length > 0) {
                        for (var i = 0; i < performent.length; i++) {
                            result += '<div class="col-md-3" ><div id="speaker">';
                            result += '<img src = "/img/performent/' + performent[i].idPerformentNavigation.img + '" class="img-fluid" style = "width:100%" >';
                            result += '<div id="details"><h3>' + performent[i].idPerformentNavigation.name + '</h3>';
                            result += '<p>Birthday: ' + convertDate(performent[i].idPerformentNavigation.dob) + '</p>';
                            if (performent[i].idPerformentNavigation.gender) {
                                result += '<p>Gender: Male</p>';
                            } else result += '<p>Gender: FeMale</p>';
                            result += '<form class="delPre" method="post">';
                            result += '<input value = "' + performent[i].idSeminar + '" name="idSeminar" hidden>';
                            result += '<input value="' + performent[i].idPerformentNavigation.id + '" name="idPerforment" hidden>';
                            result += '<button class="btn btn-gradient-danger" type ="submit" > <i class="mdi mdi-delete"></i></button >';
                            result += '</form ></div></div></div>';
                        }
                    } else {
                        result += '<div class="alert alert-danger" role="alert">THERE IS NO DATA!!!</div >';
                    }
                    $('#listPer').html(result);
                    alert("Success");
                }
            });
        }
    });

    $("#ModalPer").on('show.bs.modal', function () {
        var idSeminar = $("#ModalPer #idSer").val();
        $.ajax({
            type: 'GET',
            url: '/admin/seminar/findPer',
            data: {
                idSeminar: idSeminar
            },
            contentType: '/application/json; charset=utf-8',
            dataType: 'json',
            success: function (performent) {
                var result = '';
                if (performent.length > 0) {
                    for (var i = 0; i < performent.length; i++) {
                        result += '<div class="col-md-4" ><div id="speaker">';
                        result += '<img src = "/img/performent/' + performent[i].img + '" class="img-fluid" style = "width:100%; height:300px" >';
                        result += '<div id="details"><h3>' + performent[i].name + '</h3>';
                        result += '<p>Birthday: ' + convertDate(performent[i].dob) + '</p>';
                        if (performent[i].gender) {
                            result += '<p>Gender: Male</p>';
                        } else result += '<p>Gender: FeMale</p>';
                        result += '<button class="btn btn-gradient-success addPerSemenar" value="' + performent[i].id + '">Add</i></button>';
                        result += '</div></div></div>';
                    }
                } else {
                    result += '<div class="alert alert-danger" role="alert">THERE IS NO DATA!!!</div >';
                }
                $('#listPer2').html(result);

            }
        })
    });
    $("#ModalPer").on("click", ".addPerSemenar", function () {
        if (confirm('are you sure?')) {
            var idSeminar = $("#ModalPer #idSer").val();
            var idPerforment = $(this).val();
            $.ajax({
                type: "POST",
                url: "/admin/seminar/addperforment",
                data: {
                    idSeminar: idSeminar,
                    idPerforment: idPerforment
                },
                success: function (performent) {
                    var result = '';
                    for (var i = 0; i < performent.length; i++) {
                        result += '<div class="col-md-3" ><div id="speaker">';
                        result += '<img src = "/img/performent/' + performent[i].idPerformentNavigation.img + '" class="img-fluid" style = "width:100%; height:300px" >';
                        result += '<div id="details"><h3>' + performent[i].idPerformentNavigation.name + '</h3>';
                        result += '<p>Birthday: ' + convertDate(performent[i].idPerformentNavigation.dob) + '</p>';
                        if (performent[i].idPerformentNavigation.gender) {
                            result += '<p>Gender: Male</p>';
                        } else result += '<p>Gender: FeMale</p>';
                        result += '<form class="delPre"><input value="' + performent[i].idPerformentNavigation.id + '" name="idPerforment" hidden>';
                        result += '<input value="' + performent[i].idSeminar + '" name="idSeminar" hidden>';
                        result += '<button class="btn btn-gradient-danger" type="submit"><i class="mdi mdi-delete"></i></button>';
                        result += '</form ></div></div></div>';
                    }
                    $('#listPer').html(result);
                    $('#ModalPer').modal('toggle');
                    alert("Success");
                }
            });
        }
    })
});
