SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE TABLE `comments` (
  `cid` int(10) UNSIGNED NOT NULL,
  `by_uid` int(11) NOT NULL,
  `mod_id` int(11) NOT NULL,
  `comment` text NOT NULL,
  `visible` int(11) NOT NULL,
  `unixtime` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `config` (
  `site_name` varchar(100) NOT NULL,
  `site_url` varchar(200) NOT NULL,
  `site_desc` text NOT NULL,
  `site_keys` text NOT NULL,
  `site_footer` text NOT NULL,
  `ads_status` int(11) NOT NULL,
  `adsense_code` text NOT NULL,
  `ads_1` text NOT NULL,
  `ads_2` text NOT NULL,
  `ads_3` text NOT NULL,
  `mpp` int(11) NOT NULL,
  `cpl` int(11) NOT NULL,
  `noi` int(11) NOT NULL,
  `mfs_upload` int(11) NOT NULL,
  `mfs_image` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `config` (`site_name`, `site_url`, `site_desc`, `site_keys`, `site_footer`, `ads_status`, `adsense_code`, `ads_1`, `ads_2`, `ads_3`, `mpp`, `cpl`, `noi`, `mfs_upload`, `mfs_image`) VALUES
('', '', '', '', '', 0, '', '', '', '', 12, 6, 6, 10, 3);

CREATE TABLE `mods` (
  `mid` int(10) UNSIGNED NOT NULL,
  `user_id` int(11) NOT NULL,
  `name` varchar(300) NOT NULL,
  `version` varchar(20) NOT NULL,
  `seo` varchar(300) NOT NULL,
  `catid` int(11) NOT NULL,
  `description` text NOT NULL,
  `author` varchar(300) NOT NULL,
  `file_id` text NOT NULL,
  `front_image` varchar(300) NOT NULL,
  `images` text NOT NULL,
  `status` int(11) NOT NULL,
  `downs` int(11) NOT NULL,
  `total_comments` int(11) NOT NULL,
  `last_edited` varchar(30) NOT NULL,
  `rej_reason` text NOT NULL,
  `unixtime` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `users` (
  `uid` int(10) UNSIGNED NOT NULL,
  `username` varchar(200) NOT NULL,
  `pass` varchar(300) NOT NULL,
  `email` varchar(300) NOT NULL,
  `rank` int(11) NOT NULL,
  `location` varchar(200) NOT NULL,
  `about` text NOT NULL,
  `website` varchar(200) NOT NULL,
  `avatar` text NOT NULL,
  `ip` varchar(30) NOT NULL,
  `unixtime` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `comments`
  ADD PRIMARY KEY (`cid`);

ALTER TABLE `mods`
  ADD PRIMARY KEY (`mid`);

ALTER TABLE `users`
  ADD PRIMARY KEY (`uid`);

ALTER TABLE `comments`
  MODIFY `cid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

ALTER TABLE `mods`
  MODIFY `mid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

ALTER TABLE `users`
  MODIFY `uid` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
