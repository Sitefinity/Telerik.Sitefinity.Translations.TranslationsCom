# Telerik.Sitefinity.Translations.TranslationsCom
A sample imlementation of a translation connector in Sitefinity.
# Prerequisities
* You must use Sitefinity 8.1 or above and you must have an Enterprise Sitefinity license.

# Configure the connector
><i>To use the sample you must add provided project to your solution with Sitefinity web application and add a reference with the <strong>Telerik.Sitefinity.Translations.TranslationsCom</strong> assembly to SitefinityWebApp.</i>

Before you can use the provided sample, you must configure Translation.com connector in Sitefinity.
Perform the following:

1. Create the connector, by clicking <i>Administration >> Settings >> Advanced >> Connectors >> Create new</i>
2. In <i>Connector name</i>, enter <strong>Translations.com</strong>
3. In <i>Connector title</i>, enter <strong>Translations.com</strong>
4. In <i>Connector type</i>, enter <strong>Telerik.Sitefinity.Translations.TranslationsCom.TranslationsComConnector</strong>
5. In <i>Enabled</i>, enter <strong>true</strong>
6. Save your changes.
7. Expand the <i>Parameters</i> of the newly created connector and create the following <i>Keys</i>    
 * <strong>url</strong> </br>In <i>Value</i>, enter the URL of the connector
 * <strong>username</strong> </br>In <i>Value</i>, enter the username
 * <strong>password</strong> </br>In <i>Value</i>, enter the password
 * <strong>userAgent</strong> </br>In <i>Value</i>, enter the agent
 * <strong>project</strong> </br>In <i>Value</i>, enter the name of the project
 * <strong>fileFormatProfile</strong> </br>In <i>Value</i>, enter the file format that the connector will accept. For example, enter 'XLIFF'
>All of the above parameters must be provided from Translations.com
 * <strong>submissionPrefix</strong> </br>In <i>Value</i>, enter the prefix for the translation submission name which will be generated and sent to the connector.

#API Overview: TranslationsComConnector
The <strong>TranslationsComConnector</strong> class has properties, which hold information about the connector. The following table provides details about each property.
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
					Object containing the configurations for the <i>Project Director Connector</i>.
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
					The short code of the <i>translations.com</i> project that this connector uses.
				</p>
			</td>
		</tr>
	</tbody>
</table>

The <strong>TranslationsComConnector</strong> class has several overriden methods from <strong>TranslationConnectorBase</strong>. The following tables provides more details about each method. 

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
					Initializes the connector. The parameter is a <code>NameValueCollection</code> object with TranslationsCom specific configuration parameters.
				</p>
			</td>
            <td>
				Yes
            </td>
		</tr>
	</tbody>
</table>

### Send methods
The following methods are called, in the order presented, when the entire translation project is sent to the external translation agency:
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
Override this method if you need to set initial values to the job context.
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
					This method is used for processing the <code>IStartProjectTaskEvent</code> that informating the translation agenecy  that a new project has started. The last parameter of the method stores the external Id for the project that, is later used to associate the translations project with the Sitefinity project. If the method has successfully sent the message, it returns 'true', otherwise, it returns 'false'.
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
					This method is used for processing the <code>ICompleteProjectTaskEvent</code> that informs the translation agency that the translation project has been completed. If the method has successfully sent the message it returns 'true', otherwise, it returns 'false'.
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
				       This method is called, if any error occures when sendind  the message for starting the project. The  following parameters are passed to the method:
<ul>
<li>The exception returned from the connector</li>
<li><code>IStartProjectTaskEvent</code></li>
<li>The translation job context</li>
</ul>

If the exception is handled in the method, the method returns 'false', otherwise 'true'.
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
					This method is used for processing the translation that is sent to the external translation service. The following parameters are passed to the method:
<ul>
<li><code>ISendTranslationTaskEvent</code></li> containing information about the translation to be sent
<li><code>ITranslationJobContext</code> job context.</li>
<li><code>translationId</code> store the external ID for the translation, that is later used to associate the translated message with the Sitefinity translation.</li>
</ul>
If the method has successfully sent the translation, it returns 'true', otherwise, it returns 'false'. 
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
					This method is called, if any error occures when sending the tranlation message. The following parameters are passed to the method:
<ul>
<li>The exception that is returned from the connector</li>
<li>The send translation task event</li>
<li>The translation job context, that is shared between messages, which are sent throught the translation connector.</li>
</ul>
If the exception is handled in the method, the method returns 'false', otherwise, it returns 'true'.
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
					This method is called after all messages are processed. Its parameter is the translation job context.
				</p>
			</td>
			<td>
				No
            </td>
		</tr>
	</tbody>
</table>

### Sync methods
The following methods are called, in the order presented, during the synchronization of the translations:
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
					This method gets the raw messages provided by the external translation agency. The messages can be of any kind.
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
This method is called for every raw message returned by the <code>GetRawMessages</code>. For every raw message one or more translation events can be returned
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
Send a confirmation message to the connector for the succesfully deliver of the translation, in order to update the status of the translation from completed to delivered. If the confirmation is successful it returns 'true' , otherwise, it returns 'false'.
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
					This method is called when the synchronization with the connector has finished.
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
					Containing information about the translation job, source and target languages. Holds a reference to the generated XLIFF file.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ITranslationJobContext</code></strong></td>
			<td>
				<p>
					Provides contextual information regarding the current project. Items can be stored in the context and are during the send execution.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>IStartProjectTaskEvent</code></strong></td>
			<td>
				<p>
					A message that is sent to the translation agency. It contain meta information such as StartDate, EndDate, and the name of the project. 
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ICompleteProjectTaskEvent</code></strong></td>
			<td>
				<p>
					Contains references to the translation and to the project.
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>ITranslationSyncContext</code></strong></td>
			<td>
				<p>
					Provides contextual information for the current project. Items can be stored in the context and are available during the sync execution.				
				</p>
			</td>
		</tr>
	<tr>
			<td><strong><code>SyncEventMessage</code></strong></td>
			<td>
				<p>
					This message contains the raw message that comes from the connector. it is used to acknowledge the acceptance of the message from the external translation agency.
				</p>
			</td>
		</tr>
	</tbody>
</table>
>###NOTE: Not all  of the above methods are used in this sample.
