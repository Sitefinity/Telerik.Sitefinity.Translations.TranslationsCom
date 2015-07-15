# Telerik.Sitefinity.Translations.TranslationsCom
A sample imlementation of a translation connector in Sitefinity.
# Prerequisities
* Sitefinity 8.1 or above

# Build and install
Register the connector in Administration -> Settings -> Advanced -> Connectors -> create new
### Connector configuration
* <strong>connector name</strong> - Translations.com
* <strong>connector title</strong> - Translations.com  
* <strong>connector type</strong> - Telerik.Sitefinity.Translations.TranslationsCom.TranslationsComConnector
* <strong>enabled</strong> - true

### Connector parameters
* <strong>url</strong> - with value url for the connector
* <strong>username</strong> - with value for username
* <strong>password</strong> - with value for password
* <strong>userAgent</strong> - with value for agent
* <strong>project</strong> - the name of the project
* <strong>fileFormatProfile</strong> - for example 'XLIFF'
* <strong>submissionPrefix</strong> - prefix for translation submission

#API Overview
##TranslationsComConnector
The <strong>TranslationsComConnector</strong> class has several properties, which hold information about the connector. The following table provides more details about each property.
### TranslationsCom specific properties
<table>
	<thead>
		<tr>
			<td><strong>Type</strong></td>
			<td><strong>Property</strong></td>
			<td><strong>Description</strong></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><strong><code>ProjectDirectorConfig</code></strong></td>
			<td><strong>ProjectDirectorConfig</strong></td>
			<td>
				<p>
					Object containing the configurations for the Project Director Connector.
				</p>
			</td>
		</tr>
		<tr>
			<td><strong><code>object</code></strong></td>
			<td><strong>SubmissionNamePrefix</strong></td>
			<td>
				<p>
					The prefix value of the submission names.
				</p>
			</td>
		</tr>
		<tr>
			<td><strong><code>string</code></strong></td>
			<td><strong>TranslationsComProjectShortCode</strong></td>
			<td>
				<p>
					The short code of the translations.com's project that this connector uses.
				</p>
			</td>
		</tr>
	</tbody>
</table>

The <strong>TranslationsComConnector</strong> class has several overriden methods from <strong>TranslationConnectorBase</strong>. The following tables provides more details about each method. Not all methods below are used in the sample.

### Initialization methods
<table>
	<thead>
		<tr>
			<td><strong>Type</strong></td>
			<td><strong>Method</strong></td>
			<td><strong>Description</strong></td>
            <td><strong>Required</strong></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><strong><code>void</code></strong></td>
			<td><strong>InitializeConnector</strong></td>
			<td>
				<p>
					Initializes the connector. As a parameter comes a <code>NameValueCollection</code> object with TranslationsCom specific configuration parameters.
				</p>
			</td>
            <td>
				Yes
            </td>
		</tr>
	</tbody>
</table>

### Send methods
The following methods are called (in the bellow order) during the sending of the whole translation project to the external translation agency.
<table>
	<thead>
		<tr>
			<td><strong>Type</strong></td>
			<td><strong>Method</strong></td>
			<td><strong>Description</strong></td>
			<td><strong>Required</strong></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><strong><code>void</code></strong></td>
			<td><strong>OnInitTranslationJobContext</strong></td>
			<td>
				<p>
					This method is called when the translation send job context is created, right before any message to the external translation service is sent.
				</p>
			</td>
			<td>
				No
			</td>
		</tr>
		<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>ProcessStartProjectEvent</strong></td>
			<td>
				<p>
					This method is used for processing the <code>IStartProjectTaskEvent</code> event that serves the purpose of informating the third party translation agenecy of the beginning of a new translation project. The last parameter of the method serves the purpose of storing an external Id for the project, which is later used to associate the translations project with the Sitefinity project. If the method has successfully sent the message 'true' should be returned, otherwise - 'false'.
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>ProcessCompleteProjectEvent</strong></td>
			<td>
				<p>
					This method is used for processing the <code>ICompleteProjectTaskEvent</code> event that serves the purpose of informating the third party translation agenecy of the compleating of a translation project. If the method has successfully sent the message 'true' should be returned, otherwise - 'false'.
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
		<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>OnStartProjectError</strong></td>
			<td>
				<p>
				       Called if any error occured during the sending of the start project message. The parameters that are passed to the method are the exception returned from the connector, the <code>IStartProjectTaskEvent</code> event and the translation job context.
					If the exception is handled in the method, the method should return 'false', otherwise 'true'.
				</p>
			</td>
			<td>
				No
            </td>
		</tr>
		<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>ProcessSendTranslationEvent</strong></td>
			<td>
				<p>
					This method is used for processing the translation send to the external translation service. The parameters that are passed to the method are the <code>ISendTranslationTaskEvent</code> containing information about the translation to be sent and the <code>ITranslationJobContext</code> job context. The last parameter of the method serves the purpose of storing an external Id for the translation, which is later used to associate the translated message with the Sitefinity translation. If the method has successfully sent the translation 'true' should be returned, otherwise - 'false'. 
					This method checks if the translation send process is ok. 
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
		<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>OnSendTranslationError</strong></td>
			<td>
				<p>
					Called if any error occured during the sending of the tranlation message. The parameters that are passed to the method are the exception returned from the connector, the send translation task event and the translation job context, that is shared between messages sent through the translation connector.
					If the exception is handled in the method, the method should return 'false', otherwise 'true'.
				</p>
			</td>
			<td>
				No
            </td>
		</tr>
		<tr>
			<td><strong><code>void</code></strong></td>
			<td><strong>OnEndSendTranslationJob</strong></td>
			<td>
				<p>
					Called after all messages are processed. As parameters comes translation job context.
				</p>
			</td>
			<td>
				No
            </td>
		</tr>
	</tbody>
</table>

### Sync methods
The following methods are called (in the bellow order) during the syncing of translations.
<table>
	<thead>
		<tr>
			<td><strong>Type</strong></td>
			<td><strong>Method</strong></td>
			<td><strong>Description</strong></td>
			<td><strong>Required</strong></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><strong><code>IEnumerable&#60;object&#62;</code></strong></td>
			<td><strong>GetRawMessages</strong></td>
			<td>
				<p>
					Gets the raw messages provided by the external translation agency. The messages can be of any kind.
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
		<tr>
			<td><strong><code>IEnumerable&#60;SyncEventMessage&#62;</code></strong></td>
			<td><strong>ExtractSyncEventMessages</strong></td>
			<td>
				<p>
Called for every raw message returned by the <code>GetRawMessages</code>. For every raw message one or more translation events can be returned
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
		<tr>
			<td><strong><code>bool</code></strong></td>
			<td><strong>AcknowledgeMessage</strong></td>
			<td>
				<p>
					Called when the message should be acknowledged with the translation agency, so that it cannot be processed again. Returns true if the acknowledge is successful, otherwise - false.
				</p>
			</td>
			<td>
				Yes
            </td>
		</tr>
		<tr>
			<td><strong><code>void</code></strong></td>
			<td><strong>OnEndSyncTranslationJob</strong></td>
			<td>
				<p>
					Called when the sync for this connector is finished.
				</p>
			</td>
			<td>
				Yes
			</td>
		</tr>
	</tbody>
</table>

### Used types

<table>
	<thead>
		<tr>
			<td><strong>Type</strong></td>
			<td><strong>Description</strong></td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><strong><code>ISendTranslationTaskEvent</code></strong></td>
			<td>
				<p>
					Containing information about the translation job, source and target languages and holds a reference to the generated XLIFF file.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ITranslationJobContext</code></strong></td>
			<td>
				<p>
					Provides contextual information regarding the current project. Items can be stored in the context and will be available further down the send execution.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>IStartProjectTaskEvent</code></strong></td>
			<td>
				<p>
					A message that is to be sent to the translation agency containing meta information such as StartDate EndDate and the name of the project. 
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ICompleteProjectTaskEvent</code></strong></td>
			<td>
				<p>
					Contains references for the translation and the project.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ITranslationSyncContext</code></strong></td>
			<td>
				<p>
					Provides contextual information regarding the current project. Items can be stored in the context and will be available further down the sync execution.				
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>SyncEventMessage</code></strong></td>
			<td>
				<p>
					This message contains the raw message that comes from the connector and is used to acknowledge the acceptance of the message with the external translation agency.
				</p>
			</td>
		</tr>
	</tbody>
</table>