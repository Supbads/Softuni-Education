function mainFunc(commands) {
	
	// let commandProcessor = (function() {
	// 	let hiddenValue = '';
	//
	// 	return function (command, arg) {
	// 		if(command === 'append'){
	// 			hiddenValue += arg;
	// 		}else if(command === 'print'){
	// 			console.log(hiddenValue);
	// 		}else if (command === 'removeStart'){
	// 			arg = Number(arg);
	// 			hiddenValue = hiddenValue.slice(arg, hiddenValue.length);
	// 		}else if (command === 'removeEnd'){
	// 			arg = Number(arg);
	// 			hiddenValue = hiddenValue.slice(0, hiddenValue.length - arg);
	// 		}
	// 	}
	// })();
	
	let commandProcessor = (function() {
		let text = '';
		return {
			append: (newText) => text += newText,
			removeStart: (count) => text = text.slice(count),
			removeEnd: (count) => text =
					text.slice(0, text.length - count),
			print: () => console.log(text)
		}
	})();
	
	for (let commandRow of commands) {
		[command, arg] = commandRow.split(' ');
		commandProcessor[command](arg);
	}
}


//mainFunc(['append 123', 'append 45', 'removeStart 2', 'removeEnd 1', 'print']);
mainFunc(['append hello',
	'append again',
	'removeStart 3',
	'removeEnd 4',
	'print']);