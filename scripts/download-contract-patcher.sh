#!/bin/bash

# Get the directory of the script
script_dir=$(dirname "$0")

# Define the path to the configuration file
config_file="$script_dir/config.sh"

# Check if the configuration file exists
if [ ! -f "$config_file" ]; then
    echo "Error: Configuration file not found"
    exit 1
fi

# Source the configuration file
source $config_file

# Print the version number
echo "Version: $CONTRACT_PLUGIN_VERSION"

# Define the array of platforms and their respective destination subfolders
platforms=("linux-x64" "win-x64" "osx-x64" "osx-arm64")
subfolders=("linux_x64" "windows_x64" "macosx_x64" "macosx_arm64")

# Loop over the platforms
for index in "${!platforms[@]}"
do
    echo "Downloading: ${platforms[index]}"
    # Define the URL
    url="https://github.com/gldeng/aelf-contract-patcher/releases/download/$CONTRACT_PLUGIN_VERSION/aelf-contract-patcher-${platforms[index]}-$CONTRACT_PLUGIN_VERSION.zip"

    # Define the target directory relative to the script directory
    dir="$script_dir/../aelf.tools/AElf.Tools/tools/${subfolders[index]}"

    # Create the target directory if it doesn't exist
    mkdir -p $dir

    # Download the zip file to the target directory
    curl -L $url --silent -o $dir/aelf-contract-patcher.zip

    # Unzip the downloaded file
    unzip -o $dir/aelf-contract-patcher.zip -d $dir

    # Remove the downloaded zip file
    rm $dir/aelf-contract-patcher.zip
done