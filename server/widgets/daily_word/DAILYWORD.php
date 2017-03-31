<?php
/**
 * Created by PhpStorm.
 * User: user
 * Date: 29/03/2017
 * Time: 15:44
 */
class DAILYWORD
{
    private $word;
    private $image;
    function __construct()
    {
        $this->word = $this->normalize('https://www.merriam-webster.com/word-of-the-day');
        $this->image=$this->images($this->word);
    }
    function normalize($url)
    {
        $page = @file_get_contents($url);
        if (!$page) return null;
        $matches = array();
        if (preg_match('/<h1>(.*?)<\/h1>/', $page, $matches)) {
            return $matches[1];
        } else {
            return null;
        }
        #create json
    }
    function images($word)
    {
        $html = @file_get_contents('https://www.google.co.il/search?q='.$word.'&espv=2&source=lnms&tbm=isch&sa=X&ved=0ahUKEwifoPbzkYDTAhUHuBQKHdaBCmQQ_AUIBigB&biw=1280&bih=615');
        preg_match_all( '|<img.*?src=[\'"](.*?)[\'"].*?>|i',$html, $matches );
        return $matches[ 1 ][ 2];
    }
    function get_word()
    {
        return $this->word;
    }
    function get_image()
    {
        return $this->image;
    }
}
?>



