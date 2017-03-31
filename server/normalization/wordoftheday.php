<?php
    $page = @file_get_contents('https://www.merriam-webster.com/word-of-the-day');
    if (!$page) return null;
    $matches = array();

    if (preg_match('/<h1>(.*?)<\/h1>/', $page, $matches)) {
        echo $matches[1];
        return $matches[1];
    }
    return null;
?>