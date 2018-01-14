/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

// Less configuration
var gulp = require('gulp');
var less = require('gulp-less');
var cleanCss = require('gulp-clean-css')

//Task which compiles less to css
gulp.task('less', function () {
    gulp.src('wwwroot/css/customcss/style.less')
        .pipe(less())
        .pipe(gulp.dest(function (f) {
            return f.base;
        }))
        .pipe(cleanCss({ compatability: 'ie8' }));
   // gulp.start('minifycss')
});

//Gulp task to minify the css files 
gulp.task("minifycss", function (f) {
    return gulp.src('wwwroot/css/customcss/style.css')
        .pipe(cleanCss({ compatability: 'ie8' }))
        .pipe(gulp.dest(function (f) { return f.base; }))
});

//Gulp task to watch out the changes to less files inside folder customcss then compiles less to CSS and minifies generated files
gulp.watch('wwwroot/css/customcss/*.less', () => {    
    gulp.src('wwwroot/css/customcss/style.less')
        .pipe(less())
        .pipe(gulp.dest(function (f) {
            return f.base;
        }))
        .pipe(cleanCss({ compatability: 'ie9' }))
        .pipe(gulp.dest(function (f) {
            return f.base;
        }));
});


//gulp.task('default', ['less'], function () {
//    gulp.watch('*.less', ['less']);
//})