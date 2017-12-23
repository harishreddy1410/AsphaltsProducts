/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

// Less configuration
var gulp = require('gulp');
var less = require('gulp-less');


//Task which compiles less to css
gulp.task('less', function () {
    gulp.src('wwwroot/css/customcss/style.less')
        .pipe(less())
        .pipe(gulp.dest(function (f) {
            return f.base;
        }))
});

gulp.task('default', ['less'], function () {
    gulp.watch('*.less', ['less']);
})