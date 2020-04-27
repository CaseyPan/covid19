# COVID-19 Campus Tracker

This is a COVID-19 tracking MS Razor web appication for schools to trace the footprint of students. Currently CRUD functions are implemented, allowing users to log geographically-tagged events and view the logged events for each student as well as each location. It serves as a robust base framework for developing higher level functions, such as notifying past encounters with verified infected students and identifying hotspots where more sanitization is needed.

## Overview

The entry point of the web app is defaulted to localhost:5001 in development environment. There are three functions provided: student management, location management, and eventlog management. Student and location management allow modifying the set of students/locations stored. Additionally, users can select individual instances to gather individually-relevant eventlog. Eventlog management allows logging events which consists information of who, where, and when.

## Data Structures

#### Student

* StudentIdNumber (string): student identifiation number
* Name (string): student name
* IsConfirmedInfected (bool): whether the student is confirmed to be infected
* IsSuspectedInfected (bool): whether the student is suspected to be infected

#### Location

* Name (string): location name
* Lon (double): longitude of the location
* Lat (double): latitude of the location

#### EventLog

* Student (Student): student associated with the event
* Loccation (Location): location associated with the event
* Timestamp (Datetime): timestamp for the eventlog (auto-generated)

## Usage

First the database for students and locations should be populated with data which would later be used for event logging. Users can browse to the respective page by clicking the tab menu to view, create, edit, and remove instances. After completely populating both databases, users may create eventlogs by directing to the eventlog page. All students and locations will be provided as options in a dropdown menu. To obtain a brief summary, users may go to the repective tabs and select individual instance for all the eventlogs for each student or location.

## Future Work

Many functionalities can be developed based on the robust CRUD framework. such as but not limited to:

* mark and notify suspected students that might be infected based on the proximity in space and time with a confirmed case
* add admin privilege (differentiating from normal user) that have access to all data while normal users can only create timestamped events
* calculate hotspot defined as a location with high frequency of confirmed or suspected infected students visiting
* support batch import students and locations in common file formats
* support export eventlogs in common file formats

Other best practices for developing web applications should be updated to gurantee secuirity and data consistency, including:

* switch from database direct creation to migration for easier development when models change and the data is intended to be kept
* add AsNoTracking to returned entities that are not currently update to improve performance
* only create/update the intended properties of a instance as opposed to the entire instance with keyword arguments to prevent overposting
* enforce stricter restrictions on the format of property input for more unified data saved in database (ex. add required properties, limit total input length) and prevent unintended behavior