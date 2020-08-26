var app = angular.module("myApp", []);

app.controller("commentController", function () {
    var vm = this;
    var articleId = window.location.pathname.substring(18);


    vm.CommentAdd = function () {
        var obj = {
            title: vm.title,
            content: vm.content,
            articleId: articleId
        };


        $.ajax({
            method: "POST",
            url: 'http://localhost:5000/Home/CommentAdd',
            async: false,
            type: "json",
            data: obj,
        }).done(function (response, statusText, jqXHR) {
            vm.PageLoad();

        }).fail(function (response, statusText, jqXHR) {

        });
    }


    vm.PageLoad = function () {

        var obj = {
            id: articleId,
        };

        $.ajax({
            method: "POST",
            url: 'http://localhost:5000/Home/CommentList',
            async: false,
            type: "json",
            data: obj,
        }).done(function (response, statusText, jqXHR) {
            vm.data = response;

        }).fail(function (response, statusText, jqXHR) {

        });

    }

    vm.PageLoad();

});