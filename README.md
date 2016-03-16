# checksum [![Build Status](https://travis-ci.org/vkocjancic/checksum.svg?branch=master)](https://travis-ci.org/vkocjancic/checksum)
Checksum for Windows directories

## Installation
Simply copy the binary found in Releases. No installation or admin rights needed.

## Create checksum
You can create checksum of a directory by issuing one of following commands:

    checksum create <path_to_your_directory> [md5|sha1|sha2]
    checksum cr <path_to_your_directory> [md5|sha1|sha2]

This will create checksum.txt file in passed directory contiaining requested checksum.

## Check checksum
You can check if checksum is valid by issuing one of following commands:

    checksum check <path_to_your_directory> [md5|sha1|sha2]
    checksum ch <path_to_your_directory> [md5|sha1|sha2]

This will recalculate checksum of directory (ignoring checksum.txt file), search for checksum.txt file, read its contents and compare results. If results differ, you will get a notification on your screen.
