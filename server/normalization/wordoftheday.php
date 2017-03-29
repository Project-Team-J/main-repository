<?php

function page_word($url) {

    $page = @file_get_contents($url);

    if (!$page) return null;

    $matches = array();

    if (preg_match('/<h1>(.*?)<\/h1>/', $page, $matches)) {
        return $matches[1];
    }
    else {
        return null;
    }
}

#create json
$json = array(

    'word' => page_word('https://www.merriam-webster.com/word-of-the-day')

);
die(json_encode($json));