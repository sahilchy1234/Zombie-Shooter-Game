#!/bin/bash
# Change directory to the "Assets" folder
cd "D:\unity projects\Zombie Shooter Project Client 14\Zombie-Shooter-Game\Assets\Dark UI"  # Replace with the actual path to your "Assets" folder
# Iterate through all subdirectories
for folder in */; do
  # Remove the trailing slash to get the folder name
  folder_name=${folder%/}
  
  # Add the folder to the Git repository
  git add "$folder_name"
  
  # Commit the changes
  git commit -m "Add folder: $folder_name"
  
  # Push the changes to GitHub
  git push origin main  # Replace 'master' with the branch you're working on
done